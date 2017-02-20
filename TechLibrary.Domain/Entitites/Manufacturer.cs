using System;
using System.Collections.Generic;
using System.Linq;
using TechLibrary.Domain.Entitites;


namespace TechLibrary.Domain.Aggregagtes
{
    public  class Manufacturer 
    {

        public Manufacturer()
        {
            ID = Guid.NewGuid();
            ModelFamilies = new List<ModelFamily>();
        }

        public Guid ID { get; private set; }

        public string Name { get; set; }

        public List<ModelFamily> ModelFamilies { get; set; }



        public List<ModelFamily> GetModelFamilyByName(string name)
        {
            return ModelFamilies.Where(mf => mf.Name == name).ToList();
        }

        public List<Series> GetAllSeriesByName(string name)
        {
            return ModelFamilies.SelectMany(ser => ser.Series).Where(v => v.Name == name).ToList();
        }


        public List<Series>  GetModelFamilySeriesByName(Guid modelFamilyId, string name)
        {
            return ModelFamilies.First(mf => mf.ID == modelFamilyId).Series.Where(v => v.Name == name).ToList();
        }




        public ModelFamily AddModel(string modelName)
        {
            var mf = new ModelFamily()
            {
                Name = modelName
            };

            ModelFamilies.Add(mf);

            return mf;
        }

        public Series AddSeriesToModel(Guid modelFamilyId, string name, int yearFrom, int yearTo)
        {
            var modelFamily = ModelFamilies.First(mf => mf.ID == modelFamilyId);

            return modelFamily.AddSeries(name, yearFrom, yearTo);
        }

        public ModelFamily GetModelFamilyByID(Guid id)
        {
            return ModelFamilies.First(mf => mf.ID == id);
        }
    }
}
