using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using static System.Console;
namespace ProjAttributes
{
    public class ContactWriter
    {
        private Contact _contact;
        private ConsoleColor _color;

        public ContactWriter(Contact contact)
        {
            _contact = contact;
        }

        //[Obsolete("This is old method", true)]
        public void Write()
        {
            WriteName();
            WriteAge();
        }

        private void WriteName()
        {
            //WriteLine( _contact.Name);

            //Property
            PropertyInfo nameProperty =
                typeof(Contact).GetProperty(nameof(Contact.Name));

            //My Custom Attribute Class
            DisplayAttribute nameDisplayAttribute = (DisplayAttribute)
                Attribute.GetCustomAttribute(nameProperty, typeof(DisplayAttribute));

            PreserveForegroundColor();
            StringBuilder sb = new StringBuilder();

            if (nameDisplayAttribute != null)
            {
                ForegroundColor = nameDisplayAttribute.Color;
                sb.Append(nameDisplayAttribute.Label);
            }

            if (_contact.Name != null)
            {
                sb.Append(_contact.Name);
            }
            
            WriteLine(sb);

            RestoreForegroundColor();
        }

        private void WriteAge()
        {
            OutputDebugInfo();
            WriteLine(_contact.Age);
        }

        [Conditional("DEBUG")]
        private void OutputDebugInfo()
        {
            WriteLine("********DEBUG MODE********");
        }

        private void PreserveForegroundColor()
        {
            _color = ForegroundColor;
        }

        private void RestoreForegroundColor()
        {
            ForegroundColor = _color;
        }
    }
}
