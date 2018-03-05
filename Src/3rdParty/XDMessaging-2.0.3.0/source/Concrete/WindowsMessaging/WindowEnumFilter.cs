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
using System.Diagnostics;
using System.Collections.Generic;

namespace TheCodeKing.Net.Messaging.Concrete.WindowsMessaging
{
    /// <summary>
    /// A class used as a WindowFilterHandler for the WindowsEnum class. This 
    /// filters the results of a windows enumeration based on whether the windows
    /// contain a named property.
    /// </summary>
    internal sealed class WindowEnumFilter
    {
        /// <summary>
        /// The property to search for when filtering the windows.
        /// </summary>
        private string property;
        /// <summary>
        /// The constructor which takes the property name used for filtering
        /// results.
        /// </summary>
        /// <param name="property">The windows property name.</param>
        public WindowEnumFilter(string property)
        {
            this.property = property;
        }
        /// <summary>
        /// The delegate used to filter windows during emuneration. Only windows 
        /// that contain a named property are added to the enum.
        /// </summary>
        /// <param name="hWnd">The window being filtered.</param>
        /// <param name="include">Indicates whether the window should be
        /// inclused in the enumeration output.</param>
        public void WindowFilterHandler(IntPtr hWnd, ref bool include)
        {
            if (Native.GetProp(hWnd, property) == 0)
                include = false;
        }
    }
}
