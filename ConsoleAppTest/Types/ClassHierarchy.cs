using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Types
{
    public class ClassHierarchy
    {

        // 2-33 The IPrintable interface (design and implement interface)
        // An interface in a C# program specifies how a software component could be  used by another software component.So, instead of starting to build an
        // application by designing classes.you should instead be thinking about describing their interfaces (what each software component will do). How the
        // component performs its function can be encapsulated inside the component.A C# interface contains a set of method signatures. If a class contains an  
        // implementation of all of the methds described in the interface it can be defined as “implementing” that interface. Interfaces allow a program to regard objects in
        // terms of their abilities(or the interfaces that they implement), rather than what type an object actually is.
        interface IPrintable
        {
            string GetText(int pageWidth, int pageHeight);
            string GetTitle();
        }

        class Protocol : IPrintable
        {
            public string GetText(int pageWidth, int pageHeight)
            {
                return "Report Text";
            }

            public string GetTitle()
            {
                return "Report Title";
            }
        }

        void PrintItem(IPrintable printable)
        {
            printable.GetText(10, 10);
            printable.GetTitle();
        }

        // 2-34

        // 2-35

        // 2-36

        // 2-37

        // 2-38

        // 2-39

        // 2-40

        // 2-41

        // 2-42

        // 2-43

        // 2-44

        // 2-45


    }
}
