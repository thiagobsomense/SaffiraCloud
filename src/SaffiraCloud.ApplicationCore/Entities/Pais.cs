using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SaffiraCloud.ApplicationCore.Entities
{
    [Table("Pais")]

    public class Pais : BaseEntity
    {
        private string _codigoIBGE;
        private string _codigoISO;

        [Required(ErrorMessage = "'{0}' deve ser informado.")]
        [StringLength(100, MinimumLength =3, ErrorMessage = "'{0}' deve ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "'{0}' deve ser informado.")]
        [Display(Name = "Código IBGE")]
        [MaxLength(3, ErrorMessage = "'{0}' deve ser menor ou igual a {1} caracteres.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Utilize apenas números no campo '{0}'.")]
        public string CodigoIBGE
        {
            get
            {
                if (string.IsNullOrEmpty(_codigoIBGE) || !_codigoIBGE.All(char.IsNumber))
                    return _codigoIBGE;

                return Convert.ToUInt64(_codigoIBGE).ToString(@"000");
            }
            set
            {
                _codigoIBGE = value;
            }
        }

        [Display(Name = "Código ISO")]
        [MaxLength(3, ErrorMessage = "'{0}' deve ser menor ou igual a {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Utilize apenas letras no campo '{0}'.")]
        public string CodigoISO
        {
            get
            {
                if (string.IsNullOrEmpty(_codigoISO))
                    return _codigoISO;

                return _codigoISO.ToUpper();
            }
            set
            {
                _codigoISO = value;
            }
        }
    }
}
