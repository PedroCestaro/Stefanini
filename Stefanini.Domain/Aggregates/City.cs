using Stefanini.Domain.Exceptions;
using Stefanini.Domain.Validations;


namespace Stefanini.Domain.Aggregates
{
    public class City
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Uf { get; private set; }

        public virtual ICollection<Person> Persons { get; private set; }

        private City() { }

        public City(string name, string uf)
        {
            Name = name;
            Uf = uf;
            ValidateValues();
        }

        public void setName(string newName)
        {
            Validates.StringValidations(newName, "Informe um nome válido");
            Name = newName;
        }

        public void setUf(string newUf)
        {
            Validates.StringValidations(newUf, "Informe um estado válido");
            Uf = newUf;
        }

        private void ValidateValues()
        {
            var validator = new CityValidation();
            var validation = validator.Validate(this);

            if (validation.Errors.Any())
                throw new DomainException(validation.Errors.FirstOrDefault().ErrorMessage);
        }

    }
}
