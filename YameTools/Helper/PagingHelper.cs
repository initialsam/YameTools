using System;
using System.Collections.Generic;
using System.Text;

namespace YameTools.Helper
{
    public class PagingHelper
    {
        public int TotalPages { get; private set; }
        public int CurrentPage { get; private set; }

        /// <summary>
        /// 分頁幫手
        /// </summary>
        /// <param name="totalCount">全部數量</param>
        /// <param name="inputPage">輸入第幾頁</param>
        /// <param name="pageSize">一頁幾筆</param>
        public PagingHelper(int totalCount, int inputPage, int pageSize)
        {
            TotalPages = totalCount / pageSize;
            if (totalCount % pageSize > 0) TotalPages++;

            CurrentPage = TotalPages > 0 ? inputPage : 0;
        }
    }
}
