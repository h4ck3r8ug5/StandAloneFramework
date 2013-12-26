function load() {

    $("#testTable").removeClass("Hide");
}

function drawHtmlTable() {
    var htmlStr = "<table id='testTable' class='Hide'><tr><td>Genre:</td><td>Animation</td></tr><tr><td>Year:</td><td>2013</td></tr><tr><td>Director:</td><td>David Soren</td>"+
                        "</tr><tr><td>Overview:</td><td>The tale of an ordinary garden snail who dreams of winning the Indy 500.</td></tr><tr><td>Imdb Rating:</td>"+
                            "<td><img src='../../Content/Images/star-on.png' /><img src='../../Content/Images/star-on.png' /><img src='../../Content/Images/star-on.png' />"+
                                "<img src='../../Content/Images/star-on.png' /><img src='../../Content/Images/star-on.png' /><img src='../../Content/Images/star-on.png' />"+
                                "<img src='../../Content/Images/star-off.png' /><img src='../../Content/Images/star-off.png' /><img src='../../Content/Images/star-off.png' />"+
                                "<img src='../../Content/Images/star-off.png' /></td></tr></table>";

    document.write(htmlStr);
}