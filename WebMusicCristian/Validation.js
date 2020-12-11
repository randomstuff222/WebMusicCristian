
function Required(ctrlID, ctrlName) {
    var txtControl = document.getElementById(ctrlID);
    var string = document.getElementById(ctrlID).value;
    var result2 = !/[^0-9A-Za-z!@#$%&*()_\-.+={[}\]]/.test(string)
    var spaceCount;

    if (result2 == false) {
        alert(' Currently, you are using illegal characters \n Please Use valid inputs for the " ' + ctrlName + ' " field.');
        txtControl.focus();

        return false;
    }

    if (txtControl.value == "" ) {
        alert('Enter a valid ' + ctrlName + '.');
        txtControl.focus();

        return false;
    }
    else {
        spaceCount = 0;
        for (var count = 0; count < string.length; count++) {
            var ch = string.substring(count, count + 1);

            if (ch == ' ') {
                spaceCount++;
            }
        }
        if (spaceCount == string.length) {
            alert('Please Enter ' + ctrlName + '.');
            txtControl.value = "";
            txtControl.focus();
            return false;
        }
    }

    return true;
}

