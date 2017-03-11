<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="tyc.aspx.cs" Inherits="NotifClavesWeb.tyc"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <style>
        <!--
        /* Font Definitions */
        @font-face {
            font-family: Wingdings;
            panose-1: 5 0 0 0 0 0 0 0 0 0;
        }

        @font-face {
            font-family: "Cambria Math";
            panose-1: 2 4 5 3 5 4 6 3 2 4;
        }

        @font-face {
            font-family: "Univers Condensed";
        }

        @font-face {
            font-family: Verdana;
            panose-1: 2 11 6 4 3 5 4 4 2 4;
        }

        @font-face {
            font-family: Tahoma;
            panose-1: 2 11 6 4 3 5 4 4 2 4;
        }

        @font-face {
            font-family: Webdings;
            panose-1: 5 3 1 2 1 5 9 6 7 3;
        }

        @font-face {
            font-family: "Wingdings 2";
            panose-1: 5 2 1 2 1 5 7 7 7 7;
        }
        /* Style Definitions */
        p.MsoNormal, li.MsoNormal, div.MsoNormal {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 0cm;
            margin-bottom: .0001pt;
            text-align: justify;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        h1 {
            margin-top: 0cm;
            margin-right: -12.45pt;
            margin-bottom: 6.0pt;
            margin-left: 0cm;
            text-align: center;
            text-indent: 0cm;
            line-height: 150%;
            page-break-after: avoid;
            background: #0193D0;
            font-size: 12.0pt;
            font-family: "Verdana",sans-serif;
        }

        h2 {
            margin-top: 12.0pt;
            margin-right: -12.45pt;
            margin-bottom: 6.0pt;
            margin-left: -12.45pt;
            text-align: justify;
            page-break-after: avoid;
            background: #0193D0;
            font-size: 12.0pt;
            font-family: "Verdana",sans-serif;
            color: white;
        }

        h3 {
            margin-top: 12.0pt;
            margin-right: 0cm;
            margin-bottom: 6.0pt;
            margin-left: 35.45pt;
            text-align: justify;
            text-indent: 0cm;
            page-break-after: avoid;
            border: none;
            padding: 0cm;
            font-size: 10.0pt;
            font-family: "Verdana",sans-serif;
        }

        h4 {
            margin-top: 12.0pt;
            margin-right: 0cm;
            margin-bottom: 6.0pt;
            margin-left: 35.45pt;
            text-align: justify;
            text-indent: 0cm;
            page-break-after: avoid;
            font-size: 10.0pt;
            font-family: "Verdana",sans-serif;
        }

        h5 {
            margin-top: 12.0pt;
            margin-right: 0cm;
            margin-bottom: 6.0pt;
            margin-left: 35.45pt;
            text-align: justify;
            text-indent: 0cm;
            page-break-after: avoid;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        h6 {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 35.45pt;
            margin-bottom: .0001pt;
            text-align: center;
            text-indent: 0cm;
            page-break-after: avoid;
            font-size: 8.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.MsoHeading7, li.MsoHeading7, div.MsoHeading7 {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 35.45pt;
            margin-bottom: .0001pt;
            text-align: center;
            text-indent: 0cm;
            page-break-after: avoid;
            font-size: 8.0pt;
            font-family: "Verdana",sans-serif;
            color: white;
            font-weight: bold;
        }

        p.MsoHeading8, li.MsoHeading8, div.MsoHeading8 {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 35.45pt;
            margin-bottom: .0001pt;
            text-align: justify;
            text-indent: 0cm;
            page-break-after: avoid;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
            font-weight: bold;
        }

        p.MsoHeading9, li.MsoHeading9, div.MsoHeading9 {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 35.45pt;
            margin-bottom: .0001pt;
            text-align: right;
            text-indent: 0cm;
            page-break-after: avoid;
            font-size: 22.0pt;
            font-family: "Verdana",sans-serif;
            font-weight: bold;
        }

        p.MsoToc2, li.MsoToc2, div.MsoToc2 {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 0cm;
            margin-bottom: .0001pt;
            text-align: justify;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.MsoToc3, li.MsoToc3, div.MsoToc3 {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 35.45pt;
            margin-bottom: .0001pt;
            text-align: justify;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.MsoCommentText, li.MsoCommentText, div.MsoCommentText {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 0cm;
            margin-bottom: .0001pt;
            text-align: justify;
            font-size: 10.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.MsoHeader, li.MsoHeader, div.MsoHeader {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 0cm;
            margin-bottom: .0001pt;
            text-align: justify;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.MsoFooter, li.MsoFooter, div.MsoFooter {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 0cm;
            margin-bottom: .0001pt;
            text-align: justify;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        a:link, span.MsoHyperlink {
            color: blue;
            text-decoration: underline;
        }

        a:visited, span.MsoHyperlinkFollowed {
            color: #954F72;
            text-decoration: underline;
        }

        p.MsoCommentSubject, li.MsoCommentSubject, div.MsoCommentSubject {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 0cm;
            margin-bottom: .0001pt;
            text-align: justify;
            font-size: 10.0pt;
            font-family: "Verdana",sans-serif;
            font-weight: bold;
        }

        p.MsoAcetate, li.MsoAcetate, div.MsoAcetate {
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 0cm;
            margin-bottom: .0001pt;
            text-align: justify;
            font-size: 8.0pt;
            font-family: "Tahoma",sans-serif;
        }

        p.Cabecera, li.Cabecera, div.Cabecera {
            mso-style-name: Cabecera;
            margin-top: 0cm;
            margin-right: -12.45pt;
            margin-bottom: 0cm;
            margin-left: -12.45pt;
            margin-bottom: .0001pt;
            text-align: center;
            background: #0193D0;
            font-size: 12.0pt;
            font-family: "Verdana",sans-serif;
            color: white;
            font-weight: bold;
        }

        p.Cabecera2, li.Cabecera2, div.Cabecera2 {
            mso-style-name: "Cabecera 2";
            margin-top: 0cm;
            margin-right: -12.45pt;
            margin-bottom: 0cm;
            margin-left: -12.45pt;
            margin-bottom: .0001pt;
            text-align: center;
            font-size: 12.0pt;
            font-family: "Verdana",sans-serif;
            font-weight: bold;
        }

        p.TablaTitulo, li.TablaTitulo, div.TablaTitulo {
            mso-style-name: "Tabla Titulo";
            margin-top: 4.0pt;
            margin-right: 0cm;
            margin-bottom: 4.0pt;
            margin-left: 0cm;
            text-align: justify;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.CabeceraTDC, li.CabeceraTDC, div.CabeceraTDC {
            mso-style-name: "Cabecera TDC";
            margin-top: 0cm;
            margin-right: -12.45pt;
            margin-bottom: 0cm;
            margin-left: -12.45pt;
            margin-bottom: .0001pt;
            background: #0193D0;
            font-size: 12.0pt;
            font-family: "Verdana",sans-serif;
            color: white;
            font-weight: bold;
        }

        p.Tabla, li.Tabla, div.Tabla {
            mso-style-name: Tabla;
            margin: 0cm;
            margin-bottom: .0001pt;
            text-align: justify;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.ListaconVietas, li.ListaconVietas, div.ListaconVietas {
            mso-style-name: "Lista con Viñetas";
            mso-style-link: "Lista con Viñetas Car";
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 53.45pt;
            margin-bottom: .0001pt;
            text-align: justify;
            text-indent: -18.0pt;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.ListaNumerada1, li.ListaNumerada1, div.ListaNumerada1 {
            mso-style-name: "Lista Numerada 1";
            margin-top: 9.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 36.9pt;
            margin-bottom: .0001pt;
            text-align: justify;
            text-indent: -22.7pt;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.ListaNumeradaa, li.ListaNumeradaa, div.ListaNumeradaa {
            mso-style-name: "Lista Numerada a";
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 51.0pt;
            margin-bottom: .0001pt;
            text-align: justify;
            text-indent: -22.65pt;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.ListaconVietas1, li.ListaconVietas1, div.ListaconVietas1 {
            mso-style-name: "Lista con Viñetas 1";
            margin-top: 3.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 0cm;
            margin-bottom: .0001pt;
            text-align: justify;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.ListaconVietas2, li.ListaconVietas2, div.ListaconVietas2 {
            mso-style-name: "Lista con Viñetas 2";
            margin-top: 3.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 102.1pt;
            margin-bottom: .0001pt;
            text-align: justify;
            text-indent: -22.7pt;
            font-size: 9.0pt;
            font-family: "Verdana",sans-serif;
        }

        p.Ttulo10, li.Ttulo10, div.Ttulo10 {
            mso-style-name: "Título 10";
            margin-top: 6.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 0cm;
            margin-bottom: .0001pt;
            text-align: justify;
            page-break-after: avoid;
            font-size: 10.0pt;
            font-family: "Verdana",sans-serif;
            font-variant: small-caps;
            color: gray;
            font-weight: bold;
        }

        span.ListaconVietasCar {
            mso-style-name: "Lista con Viñetas Car";
            mso-style-link: "Lista con Viñetas";
            font-family: "Verdana",sans-serif;
        }
        /* Page Definitions */
        @page WordSection1 {
            size: 595.3pt 841.9pt;
            margin: 72.0pt 70.9pt 70.9pt 3.0cm;
        }

        div.WordSection1 {
            page: WordSection1;
        }
        /* List Definitions */
        ol {
            margin-bottom: 0cm;
        }

        ul {
            margin-bottom: 0cm;
        }
        -->
    </style>
    <table class="tyc">
        <tr>
            <td>
                <div style="overflow: auto; width: 750px; height: 500px; color: Black; overflow-x: hidden">
                    <p class="Cabecera" style='margin-left: 0cm'>
                        <span lang="ES-TRAD">Gerencia de Seguridad Informática</span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="ES-TRAD">&nbsp;</span>
                    </p>
                    <p class="Cabecera2" style='margin-left: 0cm'>
                        <span lang="ES-TRAD">Anexo</span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="ES">&nbsp;</span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="ES">&nbsp;</span>
                    </p>
                    <table class="MsoNormalTable" border="0" cellspacing="0" cellpadding="0" width="586"
                        style='width: 439.45pt; border-collapse: collapse'>
                        <tr>
                            <td width="84" valign="top" style='width: 63.25pt; padding: 0cm 3.5pt 0cm 3.5pt'>
                                <p class="TablaTitulo">
                                    <span lang="ES">Título:</span>
                                </p>
                            </td>
                            <td width="502" valign="top" style='width: 376.2pt; padding: 0cm 3.5pt 0cm 3.5pt'>
                                <p class="TablaTitulo">
                                    <span lang="ES-MX">Reglamento sobre el Uso de los Recursos Informáticos de la Entidad</span>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="84" valign="top" style='width: 63.25pt; padding: 0cm 3.5pt 0cm 3.5pt'>
                                <p class="TablaTitulo">
                                    <span lang="ES">Versión:</span>
                                </p>
                            </td>
                            <td width="502" valign="top" style='width: 376.2pt; padding: 0cm 3.5pt 0cm 3.5pt'>
                                <p class="TablaTitulo">
                                    <span lang="ES-MX">Diciembre 2014</span>
                                </p>
                            </td>
                        </tr>
                    </table>
                    <p class="MsoNormal">
                        <span lang="ES">&nbsp;</span>
                    </p>
                    <span lang="ES" style='font-size: 9.0pt; font-family: "Verdana",sans-serif'>
                        <br clear="all" style='page-break-before: always'>
                    </span>
                    <p class="MsoNormal">
                        <span lang="ES">&nbsp;</span>
                    </p>
                    <h2 style='margin-left: 0cm'>
                        <a name="_Toc146953750"><span lang="ES">Objetivo</span></a></h2>
                    <p class="MsoNormal">
                        <span lang="ES">Publicar los lineamientos generales sobre el uso de los recursos informáticos
                                establecidos en el ámbito del Banco Macro, con el fin de estandarizar su forma de
                                utilización e identificar tipos de uso no permitidos. </span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="ES">De esta forma se le brinda al usuario un marco de referencia orientado
                                a fijar el correcto uso de los recursos informáticos del Banco, conforme a las funciones
                                asignadas a los mismos.</span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="ES">Aquellas acciones no definidas expresamente en este documento pero que
                                puedan afectar a la integridad de la información o a los recursos informáticos de
                                la Entidad, deberán ser entendidas por los usuarios como una acción no autorizada.
                                Asimismo, este reglamento debe interpretarse como complementario de la normativa
                                existente sobre el tema. </span>
                    </p>
                    <h2 style='margin-left: 0cm'>
                        <a name="_Toc146953751"><span lang="ES">Alcance</span></a></h2>
                    <p class="MsoNormal">
                        <span lang="ES">El presente documento alcanza a todo el personal del Banco Macro, incluyendo
                                proveedores que utilicen la red del Banco.</span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="ES">Habiéndose publicado la normativa respecto del contenido del presente
                                reglamento, el usuario no podrá aducir desconocimiento del mismo independientemente
                                de la aceptación del presente documento. Por otra parte, se considera que el responsable
                                de cada área o sucursal debe velar en forma permanente por el buen uso del software
                                y hardware. </span>
                    </p>
                    <h2 style='margin-left: 0cm'>
                        <a name="_Toc146953752"><span lang="ES">Descripción</span></a></h2>
                    <p class="MsoNormal">
                        <span lang="ES">Las pautas establecidas se presentan agrupadas bajo el siguiente criterio:
                        </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Seguridad Lógica</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Hardware e Instalaciones</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Software </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Resguardo de Información </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Internet</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Correo</span>
                    </p>
                    <div style='border: none; border-bottom: solid #0193D0 1.0pt; padding: 0cm 0cm 1.0pt 0cm; margin-left: 35.45pt; margin-right: 0cm'>
                        <h3 style='margin-left: 0cm; text-indent: 0cm'>
                            <a name="_Toc123379272"><span lang="ES">Seguridad lógica</span></a></h3>
                    </div>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Claves</span></h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Deben utilizarse contraseñas robustas, cuya longitud no
                                sea inferior a ocho caracteres. Deben estar formadas por una mezcla de caracteres
                                alfabéticos (donde se combinen las mayúsculas y las minúsculas), dígitos e incluso
                                caracteres especiales (@, ¡, +, &amp;).</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Las contraseñas deben ser fáciles de recordar pero difíciles
                                de descifrar. Un buen método para crear una contraseña sólida es pensar en una frase
                                fácil de memorizar y utilizar la primera letra de cada palabra para construirla.
                                Luego agregar números y caracteres especiales. </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">La contraseña no debe contener el nombre de usuario de
                                la cuenta, o cualquier otra información personal que sea fácil de averiguar.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Evitar utilizar la misma contraseña para las distintas
                                aplicaciones que utilice.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">No se deben almacenar las contraseñas en un lugar público
                                y al alcance de los demás.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben compartir o difundir sus claves
                                de acceso a los distintos aplicativos, sistemas o dispositivos que tengan en su
                                poder, ya que son de uso particular. El usuario es responsable por las acciones
                                que se ejecuten en cualquier sistema bajo su cuenta de usuario.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Cuando un usuario ingrese por primera vez al sistema,
                                este le solicitará cambio de clave. Si en algún caso, esto no se produjera automáticamente,
                                es obligación de cada uno de los usuarios cambiar su clave de acceso luego del primer
                                ingreso al mismo.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Las claves de acceso tienen un período de vigencia de
                                30 días corridos. El sistema a partir del día 25 genera un aviso al usuario recordándole
                                que debe cambiarla. </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Es recomendable cambiar la clave de acceso –contraseña-
                                ese mismo día a fin de evitar su olvido y el consecuente bloqueo de la cuenta por
                                parte del sistema. </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Luego de 3 (tres) intentos fallidos en el ingreso de la
                                clave, el sistema bloquea automáticamente la cuenta de usuario, debiendo solicitarse
                                su desbloqueo.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">El usuario debe autogestionar el desbloqueo de clave a
                                través del aplicativo Tivoli. Para ello deberá enrolarse previamente en dicho aplicativo
                                siguiendo los pasos descriptos en el Instructivo “Enrolado y restablecimiento de
                                clave de red”. </span>
                    </p>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Confidencialidad de la información </span>
                    </h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben manejar la información del Banco siguiendo
                                los lineamiento definidos en el acuerdo de confidencialidad firmado.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben comentar o difundir información de la Entidad o de terceros bajo resguardo de la Entidad, a la cual tengan acceso como por ejemplo datos de clientes, saldos u otra información clasificada como Confidencial (C-3) o Secreta   (C-4). Asimismo no deben entregar a personas ajenas a la entidad información impresa o en soporte magnético con datos de la entidad, excepto en los casos que los solicite un ente externo autorizado. Ver “Norma de Clasificación de Activos de Información”.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben almacenar información de la entidad clasificada como de Uso Interno (C-2) o mayor en equipos que no sean del Banco (computadoras portátiles, computadoras públicas o de su propiedad, etc.), con la excepción de correos electrónicos guardados o información que se deba proporcionar por contrato a un tercero (vendedor, proveedor u otra entidad).</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben almacenar los documentos de su autoría clasificados como información Confidencial (C-3) o Secreta (C-4) en carpetas o directorios separados de los documentos con clasificación Pública (C-1) ó Uso Interno (C-2).</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben ser concientes sobre los riesgos existentes en su puesto de trabajo para poder identificarlos y minimizarlos. Deben considerar los riesgos relacionados con la ingeniería social a través de conversaciones telefónicas, correo de voz, fax y el uso inapropiado del correo electrónico.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben dejar el puesto de trabajo con su clave activa o conectada a ningún sistema y/ o aplicativo o a la red, ya que este hecho posibilita el uso indebido de la misma. Por lo tanto el usuario, ante su ausencia, debe dejar el puesto de trabajo con la pantalla de inicio de sesión.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Las responsabilidades respecto al resguardo y seguridad de la información confidencial como ser uso indebido, difusión, y demás directrices especificadas en el presente documento, tendrán vigentes después de la desvinculación del empleado.</span>
                    </p>
                    <h4 style='text-indent: 0cm'>
                        <a name="_Toc123379273"><span lang="ES">Incidentes de Seguridad de </span></a><span
                            lang="ES">la Información</span></h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Se considera un “Incidente de Seguridad de la Información”
                                a todo evento adverso que involucre cualquier sistema o red de comunicación que
                                procese, almacene o transmita información del Banco, y que pueda comprometer la
                                confidencialidad, integridad, y/o disponibilidad de la misma; ya sea mediante la
                                explotación de alguna vulnerabilidad o un intento o amenaza de traspasar las medidas
                                de seguridad existentes. Ver “<span style='color: black'>Administración de Incidentes
                                    de Seguridad de la Información”.</span></span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol; color: black'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben informar <span style='color: black'>a la Gerencia de Seguridad Informática,</span> en forma personal, telefónica o mediante
                                correo electrónico, cualquier posible incidente de Seguridad de la Información apenas
                                lo detecten<span style='color: black'>. </span></span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben, bajo ninguna circunstancia, intent<span
                            class="ListaconVietasCar">ar probar una posible debilidad en la seg</span>uridad.</span>
                    </p>
                    <div style='border: none; border-bottom: solid #0193D0 1.0pt; padding: 0cm 0cm 1.0pt 0cm; margin-left: 35.45pt; margin-right: 0cm'>
                        <h3 style='margin-left: 0cm; text-indent: 0cm'>
                            <span lang="ES">Hardware e Instalaciones</span></h3>
                    </div>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Instalación y reubicación física de equipamiento informático</span></h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben cambiar de lugar ningún tipo de
                                equipamiento ya instalado por el personal autorizado, como por ejemplo impresoras,
                                PC, monitores o cualquier otro dispositivo que se encuentre en las instalaciones
                                de la entidad.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben efectuar cambios respecto al uso
                                y disposición del cableado correspondiente al equipamiento instalado.</span>
                    </p>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Instalaciones eléctricas existentes (Instalación eléctrica exclusiva
                                para sistemas)</span></h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben hacer uso de los toma corriente
                                destinados para equipamiento informático con el fin de conectar otro tipo de artefactos
                                eléctricos. En caso de ser necesario se deberá consultar o solicitar el requerimiento
                                al personal de la Gerencia de Tecnología.</span>
                    </p>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Dimensionamiento y asignación de nuevo equipamiento </span>
                    </h4>
                    <p class="ListaconVietas" style='margin-left: 53.3pt; text-indent: -17.85pt; page-break-after: avoid'>
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">El equipamiento a asignar al usuario dependerá de la función
                                del mismo y será asignado teniendo en cuenta los grupos definidos de acuerdo al
                                destino del uso (ver Estándar Configuración de PC´s de Escritorio y Equipos Portátiles).</span>
                    </p>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Responsabilidad en el cuidado del equipamiento informático </span>
                    </h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios son responsables de mantener el buen estado
                                del equipamiento informático asignado para el cumplimiento de sus funciones.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">La custodia de los recursos informáticos asignados al
                                área o sucursal quedan bajo la responsabilidad del responsable máximo del área o
                                sucursal.</span>
                    </p>
                    <h4 style='text-indent: 0cm'>Dispositivos<span lang="EN-US"> de</span><span lang="EN-US"> </span><span lang="ES">almacenamiento</span><span lang="ES"> </span><span lang="EN-US">portátiles</span></h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben utilizar los dispositivos de almacenamiento
                                portátiles solamente para el traslado de información entre equipos del Banco. No
                                se deben utilizar estos dispositivos de almacenamiento para resguardo permanente
                                de datos o archivos de trabajo.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben solicitar a la Gerencia de Seguridad
                                Informática, a través del Responsable del Área, la habilitación para el uso de este
                                tipo de dispositivos. justificando su necesidad. Estas solicitudes, deben contar
                                con la autorización del Gerente de primera línea.</span>
                    </p>
                    <div style='border: none; border-bottom: solid #0193D0 1.0pt; padding: 0cm 0cm 1.0pt 0cm; margin-left: 35.45pt; margin-right: 0cm'>
                        <h3 style='margin-left: 0cm; text-indent: 0cm'>
                            <a name="_Toc123379274"><span lang="ES">Software</span></a></h3>
                    </div>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Instalación, desinstalación y configuración </span>
                    </h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben instalar y/ o desinstalar ningún
                                tipo de software o aplicativo en su puesto de trabajo, ya sea software libre o software
                                del que posea una licencia para su utilización. Dichas tareas sólo pueden ser efectuadas
                                por personal autorizado por la Gerencia de Tecnología.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben modificar la configuración del sistema
                                y/ o dispositivos de los puestos de trabajo.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">No pueden instalarse programas para ser probados en el
                                ambiente productivo. En los casos en que sea necesario, la Gerencia de Tecnología
                                probará dicho programa y una vez homologado se podrá solicitar su instalación.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben utilizar las herramientas de software
                                del Banco para realizar actividades consideradas ilícitas por la Ley de Delitos
                                Informáticos como por ejemplo para el envío de correo spam o de virus. </span>
                    </p>
                    <div style='border: none; border-bottom: solid #0193D0 1.0pt; padding: 0cm 0cm 1.0pt 0cm; margin-left: 35.45pt; margin-right: 0cm'>
                        <h3 style='margin-left: 0cm; text-indent: 0cm'>
                            <a name="_Toc123379275"><span lang="ES">Resguardo de Información</span></a></h3>
                    </div>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Archivos y Datos propios</span></h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">La información del Banco que utilicen los usuarios para
                                desarrollar sus tareas cotidianas no se debe almacenar bajo ningún concepto en los
                                discos locales de las estaciones de trabajo, sino en los repositorios definidos
                                a tal fin. </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios son responsables de resguardar aquella información
                                de uso y/o desarrollo propio que les sea necesaria para el buen desempeño en sus
                                tareas cotidianas y que consideren importante. </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben utilizar las carpetas disponibles en
                                los servidores de archivos para el almacenamiento de todo el material de trabajo
                                que constituya un activo de información que sea necesario para el desempeño en sus
                                tareas cotidianas.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben utilizar los recursos informáticos
                                para el cumplimiento de sus funciones en el ámbito del Banco. Si bien, el Banco
                                reconoce la necesidad de los empleados de atender cuestiones personales en el ámbito
                                de trabajo y con los recursos de la Entidad, esto no debe interferir con los intereses
                                de la Entidad. Por lo tanto en caso de almacenar en los equipos del Banco archivos
                                personales, debe considerarse el tamaño de los mismos de manera que no interfiera
                                en el desempeño del equipo (se prohíbe el almacenamiento de archivos de música y
                                video). Los usuarios no deben agregar a sus puestos de trabajo archivos adicionales
                                a los estándares ya configurados.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben clasificar los documentos de su autoría
                                siguiendo los lineamientos definidos en la Norma de Clasificación de Activos de
                                Información. También deberán ser administrados por los usuarios en función de su
                                clasificación. Ver Norma de Usuario Final.</span>
                    </p>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Uso del espacio en disco y buzón de correo</span></h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios son responsables de la administración del
                                espacio en disco disponible, lo cual contempla la depuración de información propia
                                no utilizada.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben administrar el espacio designado de
                                su buzón de correo. En función de ello deben aplicar depuraciones periódicas.</span>
                    </p>
                    <div style='border: none; border-bottom: solid #0193D0 1.0pt; padding: 0cm 0cm 1.0pt 0cm; margin-left: 35.45pt; margin-right: 0cm'>
                        <h3 style='margin-left: 0cm; text-indent: 0cm'>
                            <a name="_Toc123379276"><span lang="ES">Internet</span></a></h3>
                    </div>
                    <h4>
                        <span lang="ES">Acceso a Internet</span></h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">La Entidad ha definido cuatro grupos de acceso a la navegación
                                en Internet:</span>
                    </p>
                    <p class="ListaconVietas" style='margin-left: 106.8pt'>
                        <span lang="ES" style='font-family: Wingdings'>ü<span style='font: 7.0pt "Times New Roman"'>&nbsp;
                        </span></span><b><span lang="ES">Grupo 1 – Acceso a Internet Avanzado:</span></b><span
                            lang="ES"> Gerentes, empleados pertenecientes al área Riesgo Operacional y otros
                                usuarios autorizados por la Gerencia de Recursos Humanos.</span>
                    </p>
                    <p class="ListaconVietas1" style='margin-left: 106.8pt; text-indent: -18.0pt'>
                        <span lang="ES" style='font-family: Wingdings'>ü<span style='font: 7.0pt "Times New Roman"'>&nbsp;
                        </span></span><b><span lang="ES">Grupo 2 – Acceso a Internet Básico:</span></b><span
                            lang="ES"> todo el personal del Banco.</span>
                    </p>
                    <p class="ListaconVietas1" style='margin-left: 106.8pt; text-indent: -18.0pt'>
                        <span lang="ES" style='font-family: Wingdings'>ü<span style='font: 7.0pt "Times New Roman"'>&nbsp;
                        </span></span><b><span lang="ES">Grupo 3 – Acceso a Internet Medio:</span></b><span
                            lang="ES"> personal del área de Sistemas.</span>
                    </p>
                    <p class="ListaconVietas1" style='margin-left: 106.8pt; text-indent: -18.0pt'>
                        <span lang="ES" style='font-family: Wingdings'>ü<span style='font: 7.0pt "Times New Roman"'>&nbsp;
                        </span></span><b><span lang="ES">Grupo 4 – Acceso a Redes Sociales:</span></b><span
                            lang="ES"> es complemento de los otros grupos. Está autorizados para el personal
                                de las Gerencias de Recursos Humanos y de Relaciones Institucionales.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">El control de acceso a Internet se realiza a través de
                                varias categorías para una única URL de Sitio Web, esta clasificación de las páginas
                                es efectuada de manera automática y dinámica.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los sitios conocidos por estar infectados con virus o
                                spyware se bloquean de manera automática, al igual que los sitios de contenido inapropiado.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Se limita el acceso a sitios que generan exceso del uso
                                del ancho de banda pudiendo afectar la operatoria de la Entidad.</span>
                    </p>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">&nbsp;</span></h4>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Uso de Internet </span>
                    </h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben utilizar únicamente los servicios de
                                Internet para los que fueron autorizados. </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los empleados no deben acceder a contenidos inapropiados
                                mientras estén en su sitio de trabajo, o mientras hacen uso de los recursos de la
                                Entidad. </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">La Entidad reconoce a los empleados la necesidad de atender
                                cuestiones personales mientras están en su puesto de trabajo o mientras usan recursos
                                de la Entidad. Es responsabilidad del empleado asegurar que las cuestiones personales
                                no afecten la calidad o productividad de su trabajo.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Se deben considerar las directrices de privacidad y confidencialidad
                                contenidas en el código de conducta del Banco, en cuanto al manejo de información
                                reservada de la Entidad.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">No se deben descargar archivos o software desde sitios
                                sospechosos porque pueden contener código potencialmente malicioso. </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Solo el personal oficialmente designado por el Banco cuenta
                                con autorización para representarla en páginas de patrocinio, redes sociales, u
                                otras páginas de medios.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Todo el contenido web, incluyendo las conexiones a otros
                                sitios, es revisado por la Gerencia de Seguridad Informática. Los sitios Web dentro
                                del Banco deben ser evaluados y aprobados por la Gerencia de Seguridad Informática
                                antes de que se publiquen en la red.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Solo pueden hacer uso de las redes sociales el personal
                                autorizado, que requiera de esos permisos para el desempeño de su función. En ningún
                                caso, pueden ser utilizadas con fines personales.</span>
                    </p>
                    <p class="ListaconVietas" style='margin-left: 0cm; text-indent: 0cm'>
                        <span lang="ES">La Entidad emplea controles técnicos para proporcionar recordatorios,
                                supervisar y hacer cumplir estas reglas.</span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="ES">En caso de no cumplirse con lo establecido en los puntos precedentes,
                                y según los equipos comprometidos, la Gerencia de Seguridad Informática podrá tomar
                                las acciones que considere más apropiadas a fin de prevenir un posible incidente
                                de seguridad.</span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="ES">&nbsp;</span>
                    </p>
                    <div style='border: none; border-bottom: solid #0193D0 1.0pt; padding: 0cm 0cm 1.0pt 0cm'>
                        <h3 style='margin-left: 0cm; text-indent: 0cm'>
                            <span lang="ES">Correo</span></h3>
                    </div>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Uso del correo </span>
                    </h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben hacer uso del correo con fines operativos
                                relacionados con el cumplimiento de las funciones en el ámbito del Banco. Pueden
                                utilizarlo con fines personales siempre que no interfieran con los intereses del
                                Banco. </span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">El correo puede ser monitoreado por el Banco.</span>
                    </p>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Envío de mensajes</span></h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios son responsables de los archivos adjuntos
                                que envían en mensajes y del daño que puedan causar, por lo tanto deben conocer
                                el contenido y función de los archivos adjuntados evitando la difusión de archivos
                                que puedan provocar problemas en la información o puestos de trabajo de los destinatarios.</span>
                    </p>
                    <h4 style='text-indent: 0cm'>
                        <span lang="ES">Recepción de mensajes</span></h4>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios deben filtrar los correos externos de origen
                                desconocido y los que sean considerados “spam” o correo no deseado. Los usuarios
                                deben verificar el emisor del correo recibido, para comprobar el origen del mensaje.
                                No deben tomar como válida o hacer uso de la información recibida de fuentes desconocidas.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Los usuarios no deben ejecutar programas adjuntos en los
                                mensajes recibidos, salvo en aquellos casos que sean enviados con expresa autorización
                                del personal de las Gerencias de Tecnología y de Desarrollo. Todas las PC`s y equipos
                                portátiles asignados a los usuarios cuentan con software antivirus, el cual verifica
                                la presencia de código malicioso en archivos adjuntos a correos electrónicos en
                                forma automática.</span>
                    </p>
                    <p class="ListaconVietas">
                        <span lang="ES" style='font-family: Symbol'>·<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span><span lang="ES">Cuando se necesite recibir mensajes desde dominios de
                                Internet clasificados por la Gerencia de Seguridad Informática como no autorizados,
                                debe solicitarse a esta Gerencia la autorización del dominio. La Gerencia de Seguridad
                                Informática evaluará la conveniencia de liberar dicho dominio y actuará en consecuencia.
                        </span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="ES">&nbsp;</span>
                    </p>
                    <span lang="ES" style='font-size: 9.0pt; font-family: "Verdana",sans-serif'>
                        <br clear="all" style='page-break-before: always'>
                    </span>
                    <p class="MsoNormal">
                        <span lang="ES">&nbsp;</span>
                    </p>
                </div>
                <br />
                <br />
                <asp:CheckBox ID="cbtyc" runat="server" AutoPostBack="true" CssClass="LabelNormal"
                    OnCheckedChanged="cbtyc_CheckedChanged" Text="Acepto el Reglamento sobre el Uso de los Recursos Informáticos" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnAceptar" CssClass="btn" Text="Aceptar" Visible="false" runat="server"
                    OnClick="btnAceptar_Click" />
                <asp:Button ID="btnVolver" CssClass="btn" Text="Volver" runat="server" OnClick="btnVolver_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
