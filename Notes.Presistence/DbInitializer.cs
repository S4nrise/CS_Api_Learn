namespace Notes.Presistence
{
    //Проверяет создана ли база данных. Если нет, она будет создана на основе контекста
    public class DbInitializer
    {
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
