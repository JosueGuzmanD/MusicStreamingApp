﻿using Core.Interfaces;
using Core.ValueObjects;

namespace Core.Entities;

public class Album: IEntity
{
    public Guid ArtistId { get; set; }
    public string Title { get; set; }
    public Duration Duration { get; set; }
    public string ImageUrl { get; set; }
    
    public List<Song> Songs { get; set; }
    
}