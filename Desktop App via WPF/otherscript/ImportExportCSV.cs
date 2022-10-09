using MetzNenger44.Models;
using System;
using System.IO;
using System.Windows;

namespace Metz_N_enger_WPF.otherscript
{
    public static class ImportCSV
    {
        public static void ParseCSV(MetzengerContext Bdd)
        {
            string fileName = "Metzenger.csv";
            string filepath = Environment.GetEnvironmentVariable("TEMP") + "\\" + fileName;

            if (File.Exists(filepath))
            {
                MessageBoxResult result = MessageBox.Show("Voulez-vous importer les données du fichier .csv dans la base de données ?", "Importer les données", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    StreamReader sr = new StreamReader(filepath);

                    int compteur = 0;

                    while (!sr.EndOfStream) //tant que mon curseur n'est pas en bas du fichier
                    {
                        compteur++;
                        string line = sr.ReadLine();
                        string[] datas = line.Split(";");

                        if (compteur > 1)
                        {
                            Bdd.UserAccounts.Add(new UserAccount(datas[0], datas[1], datas[2], datas[3], datas[4], datas[5], datas[6], int.Parse(datas[7])));
                            Bdd.SaveChanges();
                        }
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Import impossible !!! Aucun fichier .csv n'a été trouvé !");
            }
        }
    }
}
