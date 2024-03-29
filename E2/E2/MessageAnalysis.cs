using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace E2.Linq
{
    public class MessageAnalysis
    {
        public List<MessageData> Messages { get; set; }

        public MessageAnalysis()
        {
            Messages = new List<MessageData>();
        }

        public static MessageAnalysis MessageAnalysisFactory(string csvAddress)
        {
            MessageAnalysis messageAnalysis = new MessageAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    messageAnalysis.AppendMessage(fields);
                }
            }

            return messageAnalysis;
        }

        public void AppendMessage(string[] fields)
        {
            Messages.Add(new MessageData(fields));
        }

        public MessageData MostRepliedMessage()
        {
            MessageData result=null;
           var first= Messages.Where(a => a.ReplyMessageId != null)
                .GroupBy(g => g.ReplyMessageId)
                .OrderByDescending(d => d.Count())
                .Select(l => l.Key)
                .First();
            foreach (var ma in Messages)
                if (ma.Id == first)
                    result = ma;

            return result;
        }

        public Tuple<string, int>[] MostPostedMessagePersons()
        {
         var list=   Messages
                 .GroupBy(g => g.Author)
                 .Where(w=> w.Key!= "Ali Heydari" && w.Key!= "Sauleh Eetemadi")
                 .Select(l => new { author = l.Key, count = l.Count() })
                 .OrderByDescending(o => o.count)
                 .Take(5)
                 .ToList();
            List<Tuple<string, int>> z = new List<Tuple<string, int>>();
            for(int i = 0; i < 5; i++)
            {
                z.Add(new Tuple<string, int>(list[i].author, list[i].count));
            }

            return z.ToArray();
        }

        public Tuple<string, int>[] MostActivesAtMidNight()
        {
           var t= Messages.Where(w => 0 <= w.DateTime.Hour && w.DateTime.Hour <= 4)
               .GroupBy(g => g.Author)
               .Select(l => new { author = l.Key, count = l.Count() })
               .OrderByDescending(o => o.count)
               .Take(5).
               ToList();
            List<Tuple<string, int>> z = new List<Tuple<string, int>>();
            for (int i = 0; i < 5; i++)
            {
                z.Add(new Tuple<string, int>(t[i].author, t[i].count));
            }

            return z.ToArray();
        }

        public string StudentWithMostUnansweredQuestions()
        {

            throw new NotImplementedException();
        }
    }
}