﻿using MediatR;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Detalis { get; set; } = default!;
        public object Details { get; set; }
    }
}
