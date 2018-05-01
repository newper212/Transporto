using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Transporto.Helpers
{
    public class ConstantHelpers
    {
        public static readonly int DEFAULT_PAGE_SIZE = 10;
        public static readonly int DEFAULT_PAGE_SIZE_MODAL = 10;
        public const String TEXTO_SELECCIONAR = "[-Seleccionar-]";

        public static class EXTENSION_REPORTE
        {
            public static readonly String PDF = "PDF";
            public static readonly String EXCEL = "XLS";
        }

        public static class CODIGO_FORMULARIO_RESERVA
        {
            public const String REGULAR = "REGUL";
            public const String CUMPLEANOS = "CUMPL";
        }

        public static class AREAS
        {
            public const string ADMIN = "Admin";
            public const string CLIENT = "Client";
            public const string DRIVER = "Driver";
        }

        public static class LAYOUT
        {
            public static readonly String MODAL_LAYOUT_PATH = "~/Views/Shared/_ModalLayout.cshtml";
            public static readonly String MODAL_EMAIL_PATH = "~/Views/Shared/_MailLayout.cshtml";
            public static readonly String DEFAULT_LAYOUT_PATH = "~/Views/Shared/_Layout.cshtml";
            public static readonly String LOGIN_LAYOUT_PATH = "~/Views/Shared/_LoginLayout.cshtml";
        }

        public static class ROL
        {
            public const string ADMINISTRADOR = "ADM";
            public const string PRODUCT_MARKER = "ANL";
            public const string RESPONSABLE_COMERCIAL = "RCO";
            public const string VISOR_FIJA = "VIF";
            public const string MOBILE = "MOB";


            public static string GetNombreRol(string Estado)
            {
                switch (Estado)
                {
                    case ADMINISTRADOR: return "Administrador";
                    case PRODUCT_MARKER: return "Product Marker";
                    case RESPONSABLE_COMERCIAL: return "Responsable Comercial";
                    case VISOR_FIJA: return "Visor Fija";
                    case MOBILE: return "Visor Mobile";
                    default: return String.Empty;
                }
            }
        }

        public static class ESTADO
        {
            public const string ACTIVO = "ACT";
            public const string INACTIVO = "INA";
            public const string PRE_RESERVADA = "PRE";
            public const string RESERVADA = "RES";
            public const string PROGRAMADA = "PRO";
            public const string EN_PROGRESO = "PGS";
            public const string FINALIZADA = "FIN";
            public const string CANCELADO = "CAN";
            public const string PEDIDO = "PED";

            public static string GetNameEstado(string Estado)
            {
                switch (Estado)
                {
                    case ACTIVO:
                        return "ACTIVO";
                    case INACTIVO:
                        return "INACTIVO";
                    case PRE_RESERVADA:
                        return "PRE RESERVADA";
                    case RESERVADA:
                        return "RESERVADA";
                    case PROGRAMADA:
                        return "PROGRAMADA";
                    case EN_PROGRESO:
                        return "EN PROGRESO";
                    case FINALIZADA:
                        return "FINALIZADA";
                    case CANCELADO:
                        return "CANCELADO";
                    case PEDIDO:
                        return "PEDIDO";
                }

                return string.Empty;
            }
            public static string GetLabelEstado(string Estado)
            {
                switch (Estado)
                {
                    case ACTIVO:
                        return "<label class='label label-success'>ACTIVO</label>";
                    case INACTIVO:
                        return "<label class='label label-danger'>INACTIVO</label>";
                    case PRE_RESERVADA:
                        return "<label class='label label-success'>ACTIVO</label>";
                    case RESERVADA:
                        return "<label class='label label-success'>RESERVADA</label>";
                        //case ACTIVO:
                        //    return "<label class='label label-success'>ACTIVO</label>";
                        //case INACTIVO:
                        //    return "<label class='label label-danger'>INACTIVO</label>";
                }
                return string.Empty;
            }
        }

        public static PagedListRenderOptions Bootstrap3Pager
        {
            get
            {
                return new PagedListRenderOptions
                {
                    DisplayLinkToFirstPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToLastPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToPreviousPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToNextPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToIndividualPages = true,
                    DisplayPageCountAndCurrentLocation = false,
                    MaximumPageNumbersToDisplay = 10,
                    DisplayEllipsesWhenNotShowingAllPageNumbers = true,
                    EllipsesFormat = "&#8230;",
                    LinkToFirstPageFormat = "««",
                    LinkToPreviousPageFormat = "«",
                    LinkToIndividualPageFormat = "{0}",
                    LinkToNextPageFormat = "»",
                    LinkToLastPageFormat = "»»",
                    PageCountAndCurrentLocationFormat = "Page {0} of {1}.",
                    ItemSliceAndTotalFormat = "Showing items {0} through {1} of {2}.",
                    FunctionToDisplayEachPageNumber = null,
                    ClassToApplyToFirstListItemInPager = null,
                    ClassToApplyToLastListItemInPager = null,
                    ContainerDivClasses = new[] { "pagination-container" },
                    UlElementClasses = new[] { "pagination" },
                    LiElementClasses = Enumerable.Empty<string>(),
                };
            }
        }

        public static Decimal RedondeoBCR(Decimal Importe)
        {
            var stringMontoRedondeado = Convert.ToInt32((Importe) * 100).ToSafeString();
            var importeTotalLength = stringMontoRedondeado.Length;
            if (stringMontoRedondeado.LastOrDefault().ToInteger() < 5)
            {
                stringMontoRedondeado = stringMontoRedondeado.Substring(0, importeTotalLength - 1) + "0";
            }
            else
            {
                stringMontoRedondeado = stringMontoRedondeado.Substring(0, importeTotalLength - 1) + "5";
            }

            return (stringMontoRedondeado.ToDecimal() / 100);
        }
    }
}