using System;
using System.Windows;
using System.Windows.Automation;
using System.Threading;

namespace Ncr.Core.Util
{
    public static class NextGenUIHelper
    {
        public static IntPtr GetNGUIHandle(string caption)
        {
            try
            {
                AutomationElement nextGenUIElement = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, caption));
                return new IntPtr(nextGenUIElement.Current.NativeWindowHandle);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(string.Format("{0}, {1}",caption, ex.ToString()));
            }
            catch 
            {
                throw;
            }
        }

        public static bool IsControlAvailable(string caption, string automationId, int timeout)
        {
            AutomationElement control = GetButton(caption, automationId);

            int start = Environment.TickCount;

            while (control == null)
            {
                Thread.Sleep(100);
                control = GetButton(caption, automationId);

                if ((Environment.TickCount - start) > 5000)
                {
                    return false;
                }
                    
            }
            return true;
        }

        private static AutomationElement GetButton(string caption, string automationId)
        {
            AutomationElement nextGenUIElement = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, caption));

            PropertyCondition cond = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            AutomationElement btn = nextGenUIElement.FindFirst(TreeScope.Descendants, cond);

            return btn;
        }
    }
}
