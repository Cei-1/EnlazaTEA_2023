using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pago
    {
        public static ML.Result Add(int IdUsuario, int IdMembresia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = (from especialistaDL in context.Especialistas
                                 where especialistaDL.IdUsuario == IdUsuario
                                 select especialistaDL).FirstOrDefault();

                    if(query != null)
                    {
                        DL.Pago DLPago = new DL.Pago();
                        DLPago.FechaPago = DateTime.Now;
                        DLPago.IdEspecialista = query.IdEspecialista;
                        DLPago.IdMembresia = IdMembresia;

                        context.Pagoes.Add(DLPago);
                        int RowsAffected = context.SaveChanges();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo registrar el pago ";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ecnontraron datos con que coincidan con el usuario";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
