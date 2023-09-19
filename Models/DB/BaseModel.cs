namespace api.Models.DB
{
    /// <summary>
    /// Base class for all db models 
    /// </summary>
    public abstract class BaseModel
    {
        public abstract Ulid Id { get; set; }

        public abstract string Slug { get; }

        /// <summary>
        /// Automatically generate slug when creating an instance
        /// </summary>
        protected BaseModel() => GenerateSlug();

        /// <summary>
        /// Algorithm for generating slug
        /// </summary>
        protected abstract void GenerateSlug();
    }
}
