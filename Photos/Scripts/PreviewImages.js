//This routine will get the selected photos from the hard drive and 
//add then to an image viewer.
//You can set it to select on one photo at the time (radiobutton) or multiple (checkbox)
//Both ways will show a check mark for the selected photo(s).
//If an file is not avlid picture format then the file will be ignored.
//
// It is set to 4 photos per row.
//
//input variable:
// true for checkbox functionality
// false for radiobutton functionality.

function PreviewImages(canSelectMultiple) {
    var ValidImageTypes = ["image/gif", "image/jpeg", "image/png", "image/bmp", "image/jpg"];
    var fileList = document.getElementById("uploadImages");
    var colNbr = 0;
    var rowNbr = 0
    var imageColNbr = "";
    var inputstring = "";


    $("#photoPlaceHolder").empty();
    try {
        for (var i = 0; i < fileList.files.length; i++) {
            if ($.inArray(fileList.files[i].type, ValidImageTypes) >= 0) {
                if (canSelectMultiple) {
                    inputstring = '<input type="radio" id="cb' + colNbr + '" onclick="checkboxClick(this);"/>'
                }
                else {
                    inputstring = '<input type="radio" id="cb' + colNbr + '" name="photos" onclick="checkboxClick(this);"/>'
                }

                if (colNbr % 4 == 0) {
                    rowNbr += 1;
                    $("#photoPlaceHolder").append('<div class="row" id="row' + rowNbr + '">' +
                        '<div class="col-md-3">' +
                        inputstring +
                        '<label class="cbLabel" for="cb' + colNbr + '"><img src=" ' + window.URL.createObjectURL(fileList.files[i]) + '" /></label>' +
                        '<div class="caption" id="imagecaption' + colNbr + '">' +
                        '</div></div></div>');
                }
                else {
                    $("#row" + rowNbr).append('<div class="col-md-3">' +
                        inputstring +
                        '<label class="cbLabel" for="cb' + colNbr + '"><img src=" ' + window.URL.createObjectURL(fileList.files[i]) + '" /></label>' +
                        '<div class="caption" id="imagecaption' + colNbr + '">' +
                        '</div></div>');
                }
                $("#imagecaption" + colNbr).append(" Name: " + fileList.files[i].name);
                $("#imagecaption" + colNbr).append("<br/>");
                $("#imagecaption" + colNbr).append(" Date: " + fileList.files[i].lastModifiedDate.toLocaleString());

                // If not using checkboxes / radiobuttons then then replace the input and label lines with the following 2 lines:
                //    '<div class="thumbnail"> ' +
                //    '<img id="displayImage' + colNbr + '" alt="test" style="height:100px;">' +

                //Also uncomment the following 2 lines
                //var imageColNbr = document.getElementById("displayImage" + colNbr);
                //imageColNbr.src = window.URL.createObjectURL(fileList.files[i]);

                // var value = $("input[name=photos]:checked").val();

                colNbr += 1;
            }
        }
    }
    catch (err) {

    }
};

function checkboxClick(control) {
    // Caption is split in following parts:
    // 0. "Name:"
    // 1. Name
    // 2. "Date:"
    // 3. Date
    // 4. Time
    // 5. AM/PM
    // Incase Name is empty a check is done to make sure "Date:" is not in the Name string.
    // To make sure that all the DateTime pieces are there a for loop with the array length is used.
    try {
        var captionText = $("#imagecaption" + control.id.replace('cb', '')).text();
        captionText = $.trim(captionText);
        var splitCaption = captionText.split(" ");
        document.getElementById("PhotoDescription").value = "";
        document.getElementById("DateTaken").value = "";

        if (splitCaption[1] == "Date:") {
            for (var i = 2; i < splitCaption.length; i++) {
                document.getElementById("DateTaken").value += splitCaption[i] + " ";
            }
        }
        else {
            document.getElementById("PhotoDescription").value = splitCaption[1];
            for (var i = 3; i < splitCaption.length; i++) {
                document.getElementById("DateTaken").value += splitCaption[i] + " ";
            }
        }
    }
    catch (err) {

    }

    if ($(control).is(':checked')) {
    }
    else {
    }

}