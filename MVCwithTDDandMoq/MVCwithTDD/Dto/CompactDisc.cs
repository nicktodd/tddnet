using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCwithTDD.Repository;

namespace MVCwithTDD.Dto
{
    public class CompactDisc
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

        public decimal? Price { get; set; }
    }

    public static class CompactDiscConverter
    {
        public static CompactDisc Convert(compact_discs disc)
        {
            return  new CompactDisc() {Artist = disc.artist, Id = disc.id, Title = disc.title, Price= disc.price};
        }

        public static compact_discs Convert(CompactDisc disc)
        {
            return new compact_discs() { artist = disc.Artist, id = disc.Id, title = disc.Title, price = disc.Price };
        }

        public static List<compact_discs> Convert(List<CompactDisc> list)
        {
            List<compact_discs> newList = new List<compact_discs>();
            foreach (CompactDisc disc in list)
            {
                newList.Add(Convert(disc));
            }
            return newList;
        } 

        public static List<CompactDisc> Convert(List<compact_discs> list)
        {
            List<CompactDisc> newList = new List<CompactDisc>();
            foreach (compact_discs disc in list)
            {
                newList.Add(Convert(disc));
            }
            return newList;
        }  
    }
}
