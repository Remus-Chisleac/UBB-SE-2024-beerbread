using app.MVVM.Model.Data.Repositories;

namespace app.MVVM.Model.Domain
{
    public class Album : GenericSongRepo
    {
        public string Description { get; set; }

        public Album(int owner, int id, string name, string description)
            : base(owner, id, name)
        {
            Description = description;
        }
    }
}
