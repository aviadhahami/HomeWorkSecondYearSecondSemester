using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
//    b. פריט 2 יציג תת-תפריט – "Info" שבו יהיו 2 פריטים:
//“Show Version” – פעולה פריט .i
//)יפעיל מתודה שמציגה את הטקסט הבא: Version: 15.2.4.0(
//“Count Words” – פעולה פריט .ii
//מפעיל מתודה במערכת שמבקשת מהמשתמש לכתוב משפט והמערכת
//אומרת לו כמה מילים יש במשפט
    interface IInfo
    {
        void ShowVersion();
        void CountWords();
    }
}
