﻿using Notes.Domain;
using AutoMapper;

namespace Notes.Application.Notes.Queries.GetNodeList
{
    public class NoteLookupDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteDto => noteDto.Id, 
                opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title, 
                opt => opt.MapFrom(note => note.Title));
        }
    }
}