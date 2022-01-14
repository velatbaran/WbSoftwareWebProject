using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbSoftwareWebProject.BusinessLayer.ManagerBase;
using WbSoftwareWebProject.BusinessLayer.Result;
using WbSoftwareWebProject.Entities.Entity;
using WbSoftwareWebProject.Entities.Messages;

namespace WbSoftwareWebProject.BusinessLayer
{
    public class ProjectsManager : MyManagerBase<Projects>
    {
        //BusinessLayerResult<Projects> layerResult = new BusinessLayerResult<Projects>();
        //public Projects FindProjects(int? id)
        //{
        //    layerResult.Result = Find(x => x.Id == id.Value);
        //    if (layerResult == null)
        //    {
        //        layerResult.AddError(ErrorMessageCode.DataNotFound, "Kayıt bulunamadı.");
        //    }
        //    return layerResult.Result;
        //}
    }
}
