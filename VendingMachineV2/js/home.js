$(document).ready(function () {
    loadSelections();
    addDollar();
    addQuarter();
    addDime();
    addNickel();
    returnChange();
    /*purchaseClick();*/
});

var selectionElement;
var newArray;
var item;
var selectedItem;


function loadSelections() {
    
    $.ajax({
        type: 'GET',
        url: 'http://vending.us-east-1.elasticbeanstalk.com/' + 'items',
        success: function (itemArray) {
            $('#errorMessage').empty();
            $('#vendSelections').empty();

            console.log(itemArray);
            newArray = itemArray;


            $.each(itemArray, function (index, item) {
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;
                var id = item.id;


                //var spanElement = document.getElementById('vendSelections');
                var button = $('<button type="button" id="itemBtn" class="btn btn-outline-dark">');
                button.click(function handleClick(event) { selectItem(item); });
                //value="' + name + '"
                $('<div type="text" class="child_top_left">' + id + "</div>").appendTo(button);
                $('<div type="text" class="container" id="name">' + name + "</div></button>").appendTo(button);
                $('<div type="text" class="container" id="price">$' + price + "</div></button>").appendTo(button);
                $('<div type="text" class="container" id="qty">Quantity left: ' + quantity + "</div></button>").appendTo(button);
                button.appendTo('#vendSelections');

            })
        },
        error: function () {
            $('#errorMessage')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error getting vending selections.'));
        }
    });
}

var currentDollar = 0;
function addDollar() {
 // make the variable into money and add a dollar each time they push the button.
    $('#addDollarButton').click(function () {
        $('#errorMessage').empty();
        var div = document.getElementById('moneyIn');
        div.setAttribute("readonly", false);
        var currentAmount = div.getAttribute('placeholder');
        if (currentAmount != "$0.00") {
            //change currentAmount to number then add 1.
            currentAmount = currentAmount.slice(1);
            var currentAmountAsDec = Number.parseFloat(currentAmount);
            div.val = (currentAmountAsDec + 1.00).toFixed(2);
        }
        else {
            div.val = 1.00.toFixed(2);
        }
        
        div.setAttribute('placeholder', '$' + div.val);
        div.setAttribute("readOnly", true);
    })
}

function addQuarter() {
    $('#addQuarterButton').click(function (event) {
        $('#errorMessage').empty();
        var div = document.getElementById('moneyIn');
        div.setAttribute("readonly", false);
        var currentAmount = div.getAttribute('placeholder');
        if (currentAmount != "$0.00") {
            //change currentAmount to number by getting rid of '$' then add .25
            currentAmount = currentAmount.slice(1);
            var currentAmountAsDec = Number.parseFloat(currentAmount);
            div.val = (currentAmountAsDec + 0.25).toFixed(2);
        }
        else {
            div.val = 0.25;
        }
        div.setAttribute('placeholder', '$' + div.val);
        div.setAttribute("readOnly", true);
    })
}

function addDime() {
    $('#addDimeButton').click(function (event) {
        $('#errorMessage').empty();
        var div = document.getElementById('moneyIn');
        div.setAttribute("readonly", false);
        var currentAmount = div.getAttribute('placeholder');
        if (currentAmount != "$0.00") {
            //change currentAmount to number by getting rid of '$' then add .10
            currentAmount = currentAmount.slice(1);
            var currentAmountAsDec = Number.parseFloat(currentAmount);
            div.val = (currentAmountAsDec + 0.10).toFixed(2);
        }
        else {
            div.val = 0.10;
        }
        div.setAttribute('placeholder', '$' + div.val);
        div.setAttribute("readOnly", true);
    })
}

function addNickel() {
    $('#addNickelButton').click(function (event) {
        $('#errorMessage').empty();
        var div = document.getElementById('moneyIn');
        div.setAttribute("readonly", false);
        var currentAmount = div.getAttribute('placeholder');
        if (currentAmount != "$0.00") {
            //change currentAmount to number by getting rid of '$' then add .05
            currentAmount = currentAmount.slice(1);
            var currentAmountAsDec = Number.parseFloat(currentAmount);
            div.val = (currentAmountAsDec + 0.05).toFixed(2);
        }
        else {
            div.val = 0.05;
        }
        div.setAttribute('placeholder', '$' + div.val);
        div.setAttribute("readOnly", true);
    })
}

function selectItem(item) {
    $('#errorMessage').empty();
    var itemBox = document.getElementById('item');
    //$('#boxContainer').style('background-color', 'green');


    itemBox.setAttribute('readonly', false);
    itemBox.val = item.name;
    itemBox.setAttribute('placeholder', itemBox.val);
    itemBox.setAttribute('readonly', true);

    var changeDiv = document.getElementById('change');
    changeDiv.setAttribute("readonly", false);
    changeDiv.setAttribute('placeholder', "");
    changeDiv.setAttribute("readonly", true);
    message.innerText = "Item selected."

    selectedItem = item;
    return item;
}

$('#makePurchaseButton').click(function (event) { handlePurchase(selectedItem); });

function handlePurchase(selectedItem) {
     {
        $('#errorMessage').empty();
        var itemBox = document.getElementById('item');
        var itemBoxText = itemBox.getAttribute('placeholder');
        var message = document.getElementById('message');
        if (selectedItem == null) {
            {
                message.innerText = "Please select an item to vend.";
                message.innerText = "Please select an item.";
                $('#errorMessage')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Please select an item.'));
            }
            return;
        }
            else {
                makePurchase(selectedItem);
            }
    };
}

function makePurchase(selectedItem) {
    var itemBox = document.getElementById('item');
    var message = document.getElementById('message');

    
    var moneyDiv = document.getElementById('moneyIn');
    var amount = moneyDiv.getAttribute('placeholder');

    var amountNum = parseFloat(amount.slice(1));
    var price = parseFloat(selectedItem.price);
    var idForUrl = selectedItem.id;

    if (amountNum < price) {
        {
            message.innerText = "Please input $" + (price - amountNum).toFixed(2);
            $('#errorMessage')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Please insert more coins.'));
        }
        return;
    }
            // check for inventory, insufficient funds, invalid item
            // if successful, change quantity

    $.ajax({
        type: 'POST',
        url: 'http://vending.us-east-1.elasticbeanstalk.com/money/' + amountNum + '/item/' + idForUrl,
        /*contentType: "application/json;charset=utf-8",*/
        data: JSON.stringify(
            {
                "id": selectedItem.id,
                "name": selectedItem.name,
                "price": selectedItem.price,
                "quantity": selectedItem.quantity
            }
        ),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data, textStatus, jqXHR) {
            $('#errorMessage').empty();
            console.log(data);
            var changeDiv = document.getElementById('change');
            changeDiv.setAttribute("readonly", false);
            changeDiv.setAttribute('placeholder', (JSON.stringify(data)));
            changeDiv.setAttribute("readonly", true);

            //itemBox.setAttribute("readonly", false);
            //itemBox.setAttribute('placeholder', "");
            //itemBox.setAttribute("readonly", true);

            message.innerText = selectedItem.name + " vended successfully. See change below.";
            
            loadSelections();
        },
        dataType: 'json',
        error: function () {
            $('#errorMessage')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service to purchase item.'));
            message.innerText = JSON.stringify(data);
        }
    });
}
    


function returnChange() {
    $('#changeReturnButton').click(function (event) {
        $('#errorMessage').empty();
        var changeDiv = document.getElementById('change');
        changeDiv.setAttribute("readonly", false);
        //make this display change...
        var div = document.getElementById('moneyIn');
        div.setAttribute("readonly", false);
        var currentAmount = div.getAttribute('placeholder');
        currentAmount = currentAmount.slice(1);
        var currentAmountAsNum = Number.parseFloat(currentAmount).toFixed(2);
        var itemBox = document.getElementById('item');
        itemBox.setAttribute('readonly', false);
        var isItemSelected = itemBox.getAttribute('placeholder');

        var quarters = 0;
        while (currentAmountAsNum >= 0.25) {
            currentAmountAsNum = (currentAmountAsNum - 0.25);
            quarters++;
        }
        var dimes = 0;
        while (currentAmountAsNum < 0.25 && currentAmountAsNum >= 0.10) {
            currentAmountAsNum = (currentAmountAsNum - 0.10);
            dimes++;
        }
        var nickels = 0;
        while (currentAmountAsNum < 0.10 && currentAmountAsNum >= 0.05) {
            currentAmountAsNum = (currentAmountAsNum - 0.05);
            nickels++;
        }
        currentAmountAsNum = ((currentAmountAsNum * 100).toFixed(2));

        if (isItemSelected == null || isItemSelected == "") {
            changeDiv.setAttribute('placeholder', ("Quarters: " + quarters + ", Dimes: " + dimes + ", Nickels: " + nickels + ", Pennies: " + currentAmountAsNum));
        }
        else {
            changeDiv.setAttribute('placeholder', "Change Returned.");
        }

        div.val = 0.00;
        div.setAttribute('placeholder', "$0.00");
        itemBox.setAttribute('placeholder', "");

        changeDiv.setAttribute("readonly", true);
        div.setAttribute("readonly", true);
        itemBox.setAttribute('readonly', true);

        message.innerText = "Change returned. Vend a new item.";

    })
}

