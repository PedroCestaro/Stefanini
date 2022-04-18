using Stefanini.Domain.Exceptions;
using Stefanini.Domain.Validations;


namespace Stefanini.Domain.Aggregates
{
    public class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public int Age { get; private set; }
        public int CityId { get; private set; }

        public virtual City City { get; private set; }


        private Person() { }

        public Person(string name, string cpf, int age, int cityId)
        {
            Name = name;
            Cpf = cpf;
            Age = age;
            CityId = cityId;
            ValidateValues();
        }

        public void setName(string newName)
        {
            Validates.StringValidations(newName, "Informe um nome válido");
            Name = newName;
        }

        public void setCpf(string newCpf)
        {
            Validates.StringValidations(newCpf, "Informe um cpf válido");
            Cpf = newCpf;
        }
        
        public void SetAge(int newAge)
        {
            Validates.GreaterThanZero(newAge, "Informe uma idade válida");
            Age = newAge;
        }

        public void SetCity(int newCityId)
        {
            Validates.GreaterThanZero(newCityId, "Informe uma cidade válida");
            CityId = newCityId;
        }

        private void ValidateValues()
        {
            var validator = new PersonValidation();
            var validations = validator.Validate(this);

            if (validations.Errors.Any())
                throw new DomainException(validations.Errors.FirstOrDefault().ErrorMessage);
        }

    }
}
