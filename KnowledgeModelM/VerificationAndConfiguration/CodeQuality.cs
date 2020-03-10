using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeModel.VerificationAndConfiguration
{
    public class CodeQuality
    {
        // MSDN: Guidelines for Names
        // To differentiate words in an identifier, capitalize the first letter of each word in the identifier. Do not use underscores to 
        // differentiate words, or for that matter, anywhere in identifiers. There are two appropriate ways to capitalize identifiers, depending 
        // on the use of the identifier:
        // PascalCasing -> class, constructor, method, constant, property, delegate, enum
        // camelCasing -> method argument, local variable, field name, 
        public void GuideLineForNames() 
        {
            // Do not use Hungarian notation or any other type identification in identifiers
            int iCounter; // AVOID
            string strName; // AVOID

            // Do not use Screaming Caps for constants or readonly variables:
            const string CONSTSTRING = "const";

            // Avoid using Abbreviations. Exceptions: abbreviations commonly used as names, such as Id, Xml, Ftp, Uri.

            // Do not use Underscores in identifiers. Exception: you can prefix private fields with an underscore:

            // Do not explicitly specify a type of an enum or values of enums (except bit fields):
            // Do not use an "Enum" suffix in enum type names:
            // Do not use "Flag" or "Flags" suffixes in enum type names:

            // Do not create names of parameters in methods (or constructors) which differ only by the register:

            // 
        }


        // SDO Best Practices Catalog - Coding Standards


        // SDO Best Practices Catalog - Automatic Code Inspection


        // SDO Best Practices Catalog - Code Review Process


        // Automated coding standards enforcement(StyleCop, Resharper)


        // Code Reviews and Toolset


        // Use Work Items(TODO, BUG etc.)


        // Preemptive Error Detection


        // Desirable characteristics of a design(minimal complexity, ease of maintenance, minimal connectedness etc)


        // Creating high quality classes


        // Creating high quality methods


        // Guidelines for initializing variables


        // Exceptions and error handling techniques


        // Best practices of working with data types


        // Code commenting practices

    }
}
