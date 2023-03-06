using Google.Protobuf;
using Microsoft.Win32;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WordAndSQL_Core.Collection;
using Document = Spire.Doc.Document;

namespace WordAndSQL_Core.Models
{
    internal class UserPassportModel
    {
        public void UpdatePassport(string path, string oldStr, string newStr)
        {
            Document document = new Document();
            document.LoadFromFile(path);

            UpdateString(ref document);

            document.SaveToFile(@"D:\projects\WordAndSQL_Core\DOC\test.docx", Spire.Doc.FileFormat.Docx);

            Process.Start(new ProcessStartInfo { FileName = @"D:\projects\WordAndSQL_Core\DOC\test.docx", UseShellExecute = true });
        }

        private void UpdateString(ref Document document)
        {
            document.Replace( "FIRSTNAME", UsersObservableCollection.SelectedUser.FirstName, false, true);
            document.Replace( "SECONDNAME", UsersObservableCollection.SelectedUser.SecondName, false, true);
            document.Replace( "SURNAME", UsersObservableCollection.SelectedUser.Surname, false, true);
            document.Replace( "BIRTHDAY", UsersObservableCollection.SelectedUser.BirthDate, false, true);
            document.Replace( "PHONE", UsersObservableCollection.SelectedUser.Telephone, false, true);
            document.Replace( "EDUCATION", UsersObservableCollection.SelectedUser.Education, false, true);
            document.Replace( "POST", UsersObservableCollection.SelectedUser.Post, false, true);
            document.Replace( "PLACEWORK", UsersObservableCollection.SelectedUser.PlaceWork, false, true);
            document.Replace( "COMMENT", UsersObservableCollection.SelectedUser.Comment, false, true);
        }
    }
}
