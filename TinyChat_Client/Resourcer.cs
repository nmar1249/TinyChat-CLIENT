
//this class manages embedded resources in dll or exe files

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Drawing;

namespace TinyChat_Client
{
    public class Resourcer
    {
        private Assembly asm;

        //container = name of dll or exe file
        public Resourcer(string container)
        {
            if (!File.Exists(container))
                throw new Exception("File does not exist.");

            asm = Assembly.LoadFrom(container);
        }

        public Resourcer(LoadMethod lm)
        {
            if (lm == LoadMethod.CurrentCode)
                asm = Assembly.GetExecutingAssembly();
            else
                asm = Assembly.GetCallingAssembly();
        }

        public Resourcer(Type containedClass)
        {
            asm = Assembly.GetAssembly(containedClass);
        }
        
        //load embedded img from dll or executable
        public Image LoadImage(string img)
        {
            //get full name if applicable
            string fullName = GetResourceFullName(img);
            if (fullName == null)
                throw new Exception("Can't find " + img + " resource in container.");

            Stream s = asm.GetManifestResourceStream(fullName);
            return Image.FromStream(s);
        }

        //load embedded icon from dll or executable
        public Icon LoadIcon(string ico)
        {
            string fullName = GetResourceFullName(ico);
            if (fullName == null)
                throw new Exception("Can't find " + ico + " resource in container.");

            Stream s = asm.GetManifestResourceStream(fullName);
            return new Icon(s);
        }

        //load embedded xml file from dll or executable

        public System.Xml.XmlDocument LoadXML(string xmlName)
        {
            string fullName = GetResourceFullName(xmlName);
            if (fullName == null)
                throw new Exception("Can't find " + xmlName + " resource in container.");

            Stream s = asm.GetManifestResourceStream(fullName);
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(s);
            return xmlDoc;
        }

        //load a generic embedded file from an dll or executable
        public Stream GetResourceStream(string resource)
        {
            string fullName = GetResourceFullName(resource);
            if (fullName == null)
                throw new Exception("Can't find " + resource + " resource in container.");

            return asm.GetManifestResourceStream(fullName);
        }

        //extracts the resource and saves it as a new file with the same name 
        public void ExtractAndSave(string resource)
        {
            string fullName = GetResourceFullName(resource);
            if (fullName == null)
                throw new Exception("Can't find " + resource + " resource in container.");

            Stream inFile = asm.GetManifestResourceStream(fullName);
            FileStream outFile = new FileStream(resource, FileMode.Create);

            int buffLen = 1024;
            byte[] buffer = new byte[buffLen];
            int bytesRead;
            do
            {
                bytesRead = inFile.Read(buffer, 0, buffLen);
                outFile.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);
            outFile.Close();
        }

        //extracts the resource and saves it as a file with the specified name
        public void ExtractAndSave(string resource, string destination)
        {
            string fullName = GetResourceFullName(resource);
            if (fullName == null)
                throw new Exception("Can't find " + resource + " resource in container.");

            Stream inFile = asm.GetManifestResourceStream(fullName);
            FileStream outFile = new FileStream(destination, FileMode.Create);

            int buffLen = 1024;
            byte[] buffer = new byte[buffLen];
            int bytesRead;
            do
            {
                bytesRead = inFile.Read(buffer, 0, buffLen);
                outFile.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);
            outFile.Close();
        }
        //get the full name of a resource
        private string GetResourceFullName(string n)
        {
            string fn = null;
            foreach(string str in asm.GetManifestResourceNames())
            {
                if(str.EndsWith(n))
                {
                    fn = str;
                    break;
                }
            }
            return fn;
        }
    }
}
