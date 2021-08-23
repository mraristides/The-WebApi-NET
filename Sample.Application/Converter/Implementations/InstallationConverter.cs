using System.Collections.Generic;
using System.Linq;
using Sample.Application.Converter.Contract;
using Sample.Application.VO;
using Sample.Domain.Entities;

namespace Sample.Application.Converter.Implementations
{
    public class InstallationConverter : IParser<InstallationVO, Installation>, IParser<Installation, InstallationVO>
    {
        public Installation Parse(InstallationVO origin)
        {
            if (origin == null) return null;
            return new Installation
            {
                Id = origin.Id,
                Local_Installation = origin.Local_Installation,
                Item_Objeto = origin.Item_Objeto,
                Local_Sup = origin.Local_Sup,
                Abc = origin.Abc,
                Description = origin.Description,
                Room = origin.Room,
                Work_Center = origin.Work_Center,
                Tag = origin.Tag,
                Cost_Center = origin.Cost_Center,
                Catalog_Profile = origin.Catalog_Profile,
                Status_Sys = origin.Status_Sys,
                Status_Usu = origin.Status_Usu,
                Creation_Date = origin.Creation_Date,
            };
        }

        public List<Installation> Parse(List<InstallationVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public InstallationVO Parse(Installation origin)
        {
            if (origin == null) return null;
            return new InstallationVO
            {
                Id = origin.Id,
                Local_Installation = origin.Local_Installation,
                Item_Objeto = origin.Item_Objeto,
                Local_Sup = origin.Local_Sup,
                Abc = origin.Abc,
                Description = origin.Description,
                Room = origin.Room,
                Work_Center = origin.Work_Center,
                Tag = origin.Tag,
                Cost_Center = origin.Cost_Center,
                Catalog_Profile = origin.Catalog_Profile,
                Status_Sys = origin.Status_Sys,
                Status_Usu = origin.Status_Usu,
                Creation_Date = origin.Creation_Date,
            };
        }

        public List<InstallationVO> Parse(List<Installation> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}