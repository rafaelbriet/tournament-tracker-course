﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextProcessing
{
    public static class TextConnectionProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (File.Exists(file) == false)
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModel(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] collumns = line.Split(',');

                PrizeModel model = new PrizeModel();

                model.Id = int.Parse(collumns[0]);
                model.PlaceNumber = int.Parse(collumns[1]);
                model.PlaceName = collumns[2];
                model.PrizeAmount = decimal.Parse(collumns[3]);
                model.PrizePercentage = double.Parse(collumns[4]);

                output.Add(model);
            }

            return output;
        }

        public static List<PersonModel> ConvertToPersonModel(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] collumns = line.Split(',');

                PersonModel model = new PersonModel();

                model.Id = int.Parse(collumns[0]);
                model.FirstName = collumns[1];
                model.LastName = collumns[2];
                model.EmailAddress = collumns[3];
                model.CellphoneNunber = collumns[4];

                output.Add(model);
            }

            return output;
        }

        public static void SavePrizesToFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel prize in models)
            {
                lines.Add($"{prize.Id},{prize.PlaceNumber},{prize.PlaceName},{prize.PrizeAmount},{prize.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SavePeopleToFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel model in models)
            {
                lines.Add($"{model.Id},{model.FirstName},{model.LastName},{model.EmailAddress},{model.CellphoneNunber}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}