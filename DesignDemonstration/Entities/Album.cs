﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Band> Bands { get; set; } = new List<Band>();
        public ICollection<Musician> Musicians { get; set; } = new List<Musician>();
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
