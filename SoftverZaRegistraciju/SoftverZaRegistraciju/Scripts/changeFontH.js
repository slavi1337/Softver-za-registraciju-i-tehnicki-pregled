var resultsDiv = document.getElementById('results');
if (resultsDiv) {
    var h4Elements = resultsDiv.getElementsByTagName('h4');
    for (var i = 0; i < h4Elements.length; i++) {
        h4Elements[i].style.fontFamily = 'Arial Rounded MT';
        h4Elements[i].style.fontWeight = 'bold';
        h4Elements[i].style.fontSize = '12pt';
    }

    var h5Elements = resultsDiv.getElementsByTagName('h5');
    for (var i = 0; i < h5Elements.length; i++) {
        h5Elements[i].style.fontFamily = 'Arial Rounded MT';
        h5Elements[i].style.fontWeight = 'bold';
        h5Elements[i].style.fontSize = '12pt';
    }

    var tableElements = resultsDiv.getElementsByTagName('table');
    for (var i = 0; i < tableElements.length; i++) {
        tableElements[i].style.fontFamily = 'Arial Rounded MT';
        tableElements[i].style.fontWeight = 'bold';
        tableElements[i].style.fontSize = '12pt';
    }
}
