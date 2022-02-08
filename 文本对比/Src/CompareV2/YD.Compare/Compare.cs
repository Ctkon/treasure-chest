using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace YD.Compare
{
    /// <summary>
    /// �Ƚ������ı�
    /// </summary>
    public class Compare
    {
        private string dataA;
        private string dataB;
        string[] aLines;
        string[] bLines;

        private Diff diff = new Diff();

        private bool isTrimSpace;
        private bool isIgnoreSpace;
        private bool isIgnoreCase;
        private ResultLine[] result;

        /// <summary>
        /// ����һ�αȽ�
        /// </summary>
        /// <param name="dataA">����A��ͨ��Ϊ�ɰ汾</param>
        /// <param name="dataB">����A��ͨ��Ϊ�°汾</param>
        public Compare(string dataA, string dataB)
        {
            if (dataA == null)
                throw new ArgumentNullException("dataA");
            if (dataB == null)
                throw new ArgumentNullException("dataB");

            this.dataA = dataA;
            this.dataB = dataB;

            this.aLines = dataA.Replace("\r", string.Empty).Split('\n');
            this.bLines = dataB.Replace("\r", string.Empty).Split('\n');
        }

        /// <summary>
        /// ȡ�ñȽϽ��
        /// </summary>
        /// <param name="isTrimSpace">�Ƿ����ÿ����λ�Ŀհ�</param>
        /// <param name="isIgnoreSpace">�Ƿ�������еĿհ�</param>
        /// <param name="isIgnoreCase">�Ƿ���Դ�Сд</param>
        /// <returns>�ȽϽ��������еļ���</returns>
        public ResultLine[] GetResult(bool isTrimSpace, bool isIgnoreSpace, bool isIgnoreCase)
        {
            //���˴αȽϵĲ����Ƿ����ϴαȽ���ͬ�������ͬ���Ѿ��������ݣ���ֱ�ӷ��ؽ��
            if (this.isTrimSpace == isTrimSpace && this.isIgnoreSpace == isIgnoreSpace && this.isIgnoreCase == isIgnoreCase)
                if (result != null)
                    return result;

            //ǩ��
            this.isTrimSpace = isTrimSpace;
            this.isIgnoreSpace = isIgnoreSpace;
            this.isIgnoreCase = isIgnoreCase;

            //���رȽϽ��
            result = getResultLineByDifferentItems();
            return result;
        }
        /// <summary>
        /// ȡ�ñȽϽ��������Ĭ�ϵĲ����������������κοհף���Сд����
        /// </summary>
        /// <returns>�ȽϽ��������еļ���</returns>
        public ResultLine[] GetResult()
        {
            return GetResult(false, false, false);
        }

        private ResultLine[] getResultLineByDifferentItems()
        {
            List<ResultLine> resultLineList = new List<ResultLine>();

            //ȡ�ò�֮ͬ��
            DifferentItem[] differentItems = diff.DiffText(dataA, dataB, isTrimSpace, isIgnoreCase, isIgnoreSpace);
            //��B������Ϊ��׼
            long lineNumberInB = 0;
            //����ÿһ����֮ͬ��
            for (long differentItemIndex = 0; differentItemIndex < differentItems.LongLength; differentItemIndex++)
            {
                //���ڵ�ǰ��֮ͬ��
                DifferentItem differentItem = differentItems[differentItemIndex];
                //ȡ����ͬ����
                lineNumberInB = AddSameLines(resultLineList, lineNumberInB, differentItem);
                //ȡ�ò�ͬ����
                lineNumberInB = AddChangedLines(resultLineList, lineNumberInB, differentItem);

            } // �Բ�֮ͬ���ı�������

            //������µ���ͬ����
            AddLastLines(resultLineList, lineNumberInB, differentItems[differentItems.LongLength - 1]);

            //���ؽ��
            return resultLineList.ToArray();
        }

        /// <summary>
        /// ȡ����ͬ����
        /// </summary>
        /// <param name="resultLineList">������б�</param>
        /// <param name="lineNumberInB">��ǰB�е�����</param>
        /// <param name="differentItem">��ǰ�Ĳ�֮ͬ��</param>
        /// <returns>��ɺ������B������</returns>
        private long AddSameLines(List<ResultLine> resultLineList, long lineNumberInB, DifferentItem differentItem)
        {
            //��A��B�������Ĳ��
            long offset = differentItem.StartB - differentItem.StartA;
            // ������ͬ����
            while ((lineNumberInB < differentItem.StartB) && (lineNumberInB < bLines.Length))
            {
                //���A��Ӧ������
                long lineNumberInA = lineNumberInB - offset;
                //����á���ͬ�������У������뵽������
                resultLineList.Add(getSameResultLine(lineNumberInB - offset, lineNumberInB));
                //��һ��
                lineNumberInB++;
            } // while

            return lineNumberInB;
        }
        /// <summary>
        /// ȡ�ò���ͬ����
        /// </summary>
        /// <param name="resultLineList">������б�</param>
        /// <param name="lineNumberInB">��ǰB�е�����</param>
        /// <param name="differentItem">��ǰ�Ĳ�֮ͬ��</param>
        /// <returns>��ɺ������B������</returns>
        private long AddChangedLines(List<ResultLine> resultLineList, long lineNumberInB, DifferentItem differentItem)
        {
            //��ͬ�е�����
            int differentLineIndex = 0;
            //�����޸ĵ���
            while (differentLineIndex < differentItem.deletedA && differentLineIndex < differentItem.insertedB)
            {
                //���A��Ӧ������
                int lineNumberInA = differentItem.StartA + differentLineIndex;
                //����á���ͬ�������У������뵽������
                resultLineList.Add(getDefferentResultLine(lineNumberInA, lineNumberInB));
                //��һ�и���ͬ��
                differentLineIndex++;
                //B������ͬʱ��һ
                lineNumberInB++;
            }

            //���A�е���������ʣ�࣬��˵����Щ���Ǵ�A��ɾ���ģ�����ɾ����Ľ����
            while (differentLineIndex < differentItem.deletedA)
            {
                //���A��Ӧ������
                int lineNumberInA = differentItem.StartA + differentLineIndex;
                //����ý���У������뵽������
                resultLineList.Add(getDeleteResultLine(lineNumberInA));
                //��һ��ɾ���У�B���������ֲ���
                differentLineIndex++;
            }
            //���B�е���������ʣ�࣬��˵����Щ�����²��뵽B�еģ����������Ľ����
            while (lineNumberInB < differentItem.StartB + differentItem.insertedB)
            {
                //����á����롱�����У������뵽������
                resultLineList.Add(getInsertResultLine(lineNumberInB));
                //B��������һ
                lineNumberInB++;
            }

            //�����޸ĺ������
            return lineNumberInB++;
        }
        /// <summary>
        /// ���ʣ����У���ͬ��
        /// </summary>
        /// <param name="resultLineList">������б�</param>
        /// <param name="lineNumberInB">��ǰB�е�����</param>
        /// <param name="lastDifferentItem">���һ����֮ͬ��</param>
        private void AddLastLines(List<ResultLine> resultLineList, long lineNumberInB, DifferentItem lastDifferentItem)
        {
            //��A��B�������Ĳ��
            long offset = (lastDifferentItem.StartB - lastDifferentItem.StartA) + (lastDifferentItem.insertedB - lastDifferentItem.deletedA);
            // ������ͬ����
            while ((lineNumberInB < bLines.Length))
            {
                //���A��Ӧ������
                long lineNumberInA = lineNumberInB - offset;
                //����á���ͬ�������У������뵽������
                resultLineList.Add(getSameResultLine(lineNumberInB - offset, lineNumberInB));
                //��һ��
                lineNumberInB++;
            } // while
        }

        private ResultLine getInsertResultLine(long lineNumberInB)
        {
            ResultLine line = new ResultLine();
            line.LineNumberA = -1;
            line.LineContentA = string.Empty;
            line.LineNumberB = lineNumberInB;
            line.LineContentB = bLines[lineNumberInB];
            line.ResultState = CompareState.Insert;
            return line;

        }
        private ResultLine getDeleteResultLine(long lineNumberInA)
        {
            ResultLine line = new ResultLine();
            line.LineNumberA = lineNumberInA;
            line.LineContentA = aLines[lineNumberInA];
            line.LineNumberB = -1;
            line.LineContentB = string.Empty;
            line.ResultState = CompareState.Delete;
            return line;
        }
        private ResultLine getDefferentResultLine(long lineNumberInA, long lineNumberInB)
        {
            ResultLine line = new ResultLine();
            line.LineNumberA = lineNumberInA;
            line.LineContentA = aLines[lineNumberInA];
            line.LineNumberB = lineNumberInB;
            line.LineContentB = bLines[lineNumberInB];
            line.ResultState = CompareState.Different;
            return line;
        }
        private ResultLine getSameResultLine(long lineNumberInA, long lineNumberInB)
        {
            ResultLine line = new ResultLine();
            line.LineNumberA = lineNumberInA;
            line.LineContentA = aLines[lineNumberInA];
            line.LineNumberB = lineNumberInB;
            line.LineContentB = bLines[lineNumberInB];
            line.ResultState = CompareState.Same;
            return line;
        }

    }
}
