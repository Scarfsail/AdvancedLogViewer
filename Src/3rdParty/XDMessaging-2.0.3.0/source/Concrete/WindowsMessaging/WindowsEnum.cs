/*=============================================================================
*
*	(C) Copyright 2007, Michael Carlisle (mike.carlisle@thecodeking.co.uk)
*
*   http://www.TheCodeKing.co.uk
*  
*	All rights reserved.
*	The code and information is provided "as-is" without waranty of any kind,
*	either expressed or implied.
*
*=============================================================================
*/
using System;
using System.Collections.Generic;

namespace TheCodeKing.Net.Messaging.Concrete.WindowsMessaging
{
    /// <summary>
    /// A utility class built ontop of the native windows API. This is used to 
    /// enumerate child windows of a parent. The class defines a delegate for the 
    /// the logic as to whether a window should or should not be included during
    /// the enumeration.
    /// </summary>
    internal sealed class WindowsEnum
    {
        /// <summary>
        /// The delegate used for processing the windows enumeration results.
        /// </summary>
        /// <param name="hWnd">The window being enumerated.</param>
        /// <param name="include">A reference to a bool, which may be set to true/false in 
        /// order to determine whether it should be included in the enumeration output.</param>
        public delegate void WindowFilterHandler(IntPtr hWnd, ref bool include);
        /// <summary>
        /// A list used to store the windows pointers during enumeration.
        /// </summary>
        private List<IntPtr> winEnumList;
        /// <summary>
        /// The delegate allocated to the instance for processing the enumerated windows.
        /// </summary>
        private WindowFilterHandler filterHandler;
        /// <summary>
        /// The constructor which takes a filter delegate for filtering enumeration results.
        /// </summary>
        /// <param name="filterHandler">A delegate which may filter the results.</param>
        public WindowsEnum(WindowFilterHandler filterHandler):this()
        {
            this.filterHandler=filterHandler;
        }
        /// <summary>
        /// A constructor used when there is no requirement to filter the enumeration results. 
        /// </summary>
        public WindowsEnum()
        {
        }
        /// <summary>
        /// Enumerates the child windows of a parent and returns a list of pointers. If a filter
        /// delegate is specified this is used to determine whether the windows are included in 
        /// the resultant list.
        /// </summary>
        /// <returns>A filtered list of child windows.</returns>
        public List<IntPtr> Enumerate()
        {
            this.winEnumList = new List<IntPtr>();
            Native.EnumWindows(OnWindowEnum, IntPtr.Zero);
            return this.winEnumList;
        }
        /// <summary>
        /// A delegate used by the native API to process the enumerated windows from the 
        /// Enumerate method call.
        /// </summary>
        /// <param name="hWnd">The window being enumerated</param>
        /// <param name="lParam">The lParam passed by the windows API.</param>
        /// <returns></returns>
        private int OnWindowEnum(IntPtr hWnd, IntPtr lParam)
        {
            bool include = true;
            if (filterHandler != null)
            {
                filterHandler(hWnd, ref include);
            }
            if (include)
            {
                this.winEnumList.Add(hWnd);
            }
            return 1;
        }
    }
}
