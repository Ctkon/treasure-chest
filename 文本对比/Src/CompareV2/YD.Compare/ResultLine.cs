using System;
using System.Collections.Generic;
using System.Text;

namespace YD.Compare
{
    /// <summary>
    /// ��ʾһ���ȽϽ����
    /// </summary>
    public struct ResultLine
    {
        /// <summary>
        /// ��Ӧ����A�е��кţ�����޶�Ӧ�У���Ϊ-1
        /// </summary>
        public long LineNumberA;
        /// <summary>
        /// ��Ӧ����B�е��кţ�����޶�Ӧ�У���Ϊ-1
        /// </summary>
        public long LineNumberB;
        /// <summary>
        /// ��Ӧ����A�е�����
        /// </summary>
        public string LineContentA;
        /// <summary>
        /// ��Ӧ����B�е�����
        /// </summary>
        public string LineContentB;
        /// <summary>
        /// ���е�״̬
        /// </summary>
        public CompareState ResultState;
    }
}
