using System;
using System.Collections.Generic;
using System.Text;

namespace YD.Compare
{
    /// <summary>
    /// һ�֮ͬ��
    /// </summary>
    internal struct DifferentItem
    {
        /// <summary>
        /// �ò�֮ͬ��������A�е���ʼ��
        /// </summary>
        public int StartA;
        /// <summary>
        /// �ò�֮ͬ��������B�е���ʼ��
        /// </summary>
        public int StartB;

        /// <summary>
        /// ��A��ɾ��������
        /// </summary>
        public int deletedA;
        /// <summary>
        /// ��B�в��������
        /// </summary>
        public int insertedB;
    }
}
