function showModalPopup(popup) {
    //var modalPopupBehavior = $find('mpePdfExpediente');
    var modalPopupBehavior = $find(popup);
    modalPopupBehavior.show();
}
function hideModalPopup(popup) {

    //var modalPopupBehavior = $find('mpePdfExpediente');
    var modalPopupBehavior = $find(popup);
    modalPopupBehavior.hide();
}

function VerExpedientePdf(titulo, modal) {
    var objPdf;
    objPdf = document.getElementById("ifrmMapa");
    objPdf.src = "../Archivos/" + titulo + ".pdf";
    showModalPopup(modal);
}

function VerMapaPdf(idDocMapa, modal) {
    var objPdf;
    objPdf = document.getElementById("ifrmMapa");
    objPdf.src = "../Archivos/" + idDocMapa + ".pdf";
    showModalPopup(modal);
}

function validaCombo(oSrc, args) {
    args.IsValid = (args.Value != "0");
}

function validaCoorEste(oSrc, args) {

    args.IsValid = (args.Value.length >= 6 && args.Value > 0);
//    if (args.Value.length > 5 && args.Value.length < 10)
//        args.IsValid = true;
//    else
//        args.IsValid = false;
}

function validaCoorNorte(oSrc, args) {
    args.IsValid = (args.Value.length >= 7 && args.Value>0);
    
 //    if (args.Value.length > 6 && args.Value.length < 10) {
//       
//        args.IsValid = true;
//        
//    }
//    else
//        args.IsValid = false;
}

function validaCodigoDM(oSrc, args) {

    if (args.Value.length >= 9 && args.Value.length <= 11) {
        args.IsValid = true;
    }
    else {
        args.IsValid = false;
    }
}

function ActiveTabChanged(sender, e) {
    var CurrentTab = $get('<%=tbDerecho.ClientID%>');
    var vIndex = sender.get_activeTab().get_tabIndex()
    var vEvento = '<%=Evento%>'
    if ((vEvento == "NUEVO" || vEvento == "EDITAR") && vIndex > 0) {
        sender.set_activeTabIndex(0);
        alert("Debe guardar el D.M. ");
    }
    return;
}




//Agregado por urbano

function validaDecimal(evt) {
    // NOTE: Backspace = 8, Enter = 13, '0' = 48, '9' = 57      
    if (window.event) {// IE
        key = evt.keyCode;
    } else {
        key = evt.which;
    }

    if ((key > 47 && key < 58) || key == 46 || key == 8) {
        return true;
    }
    else {
        return false;
    }

}
function validaEntero(evt) {
    // NOTE: Backspace = 8, Enter = 13, '0' = 48, '9' = 57      
    if (window.event) {// IE
        key = evt.keyCode;
    } else {
        key = evt.which;
    }

    if (key > 47 && key < 58 || key == 8) {
        return true;
    }
    else {
        return false;
    }
}

function soloLetras(evt) {

    if (window.event) {// IE
        key = evt.keyCode;
    } else {
        key = evt.which;
    }

    if (key > 65 && key < 90 || key > 97 && key < 122 || key == 8 || key == 32) {

        return true;
    }
    else {
        return false;
    }

}
/* ****************************************************************** */

function cerrarAlerta(idAlerta) {
    document.getElementById(idAlerta).style.display = 'none'
}


/* utilizida por Consulta D.M. */
function MostrarDiv(idDiv, img) {

    if (document.getElementById(idDiv, img).style.display == 'none') {
        document.getElementById(idDiv).style.display = ''
        document.getElementById(img).src = '../files/collapse_blue.jpg'
    }

    else {

        document.getElementById(idDiv).style.display = 'none'
        document.getElementById(img).src = '../files/expand_blue.jpg'
    }
}




function soloLetras(evt) {

    if (window.event) {// IE
        key = evt.keyCode;
    } else {
        key = evt.which;
    }

    if (key > 64 && key < 91 || key > 96 && key < 123 || key == 8 || key == 32) {

        return true;
    }
    else {
        return false;
    }

}



/* Hector */
function compare_dates(fecha, fecha2)
{   
    var xMonth=fecha.substring(3, 5);   
    var xDay=fecha.substring(0, 2);   
    var xYear=fecha.substring(6,10);   
    var yMonth=fecha2.substring(3, 5);   
    var yDay=fecha2.substring(0, 2);   
    var yYear=fecha2.substring(6,10);   
    if (xYear >= yYear)   
    {   
        return(true)   
    }   
    else  
    {   
      if (xYear == yYear)   
      {    
        if (xMonth >= yMonth)
        {   
            return(true)   
        }   
        else  
        {    
          if (xMonth == yMonth)   
          {   
            if (xDay >= yDay)   
              return(true);   
            else  
              return(false);   
          }   
          else  
            return(false);   
        }   
      }   
      else  
        return(false);   
    }   
}  

function validaPDF(oSrc, args)
{
        var doc=args.Value;         
        var ext=doc.substring(doc.length-3);
        if(ext=="pdf")
        {
            args.IsValid=true 
        }
        else 
        {
            args.IsValid=false  
        }
}

function validaExcel(oSrc, args)
{
        var doc=args.Value;         
        var ext=doc.substring(doc.length-3);
        if(ext=="xls" || ext=="lsx")
        {
            args.IsValid=true 
        }
        else 
        {
            args.IsValid=false  
        }
}
/*Summit*/
function ValidNum(e) {
    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    return ((tecla > 47 && tecla < 58) || tecla == 46);
}
function ValidText(e) {
    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    return ((tecla > 64 && tecla < 123) || tecla == 46 || tecla == 32);
}






