using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Threading;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateNoteCommandHandler(INotesDbContext dbcontext) => _dbcontext = dbcontext;
        public async Task /*Чет не так с < >*/ Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Details = request.Detalis;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            //return Unit.Value;

            //Тут что-то может работать не так, а может и так
        }
    }
}
