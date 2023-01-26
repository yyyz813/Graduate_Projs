/* Notes: Have to run a local server to use AJAX, beacause the website need to run on a 
local server to use GET and POST.
How to set up a local server : https://www.youtube.com/watch?v=tk8wLMJ7diQ
Or just using extension Live Server in VS Code
*/

async function load(){

    const response = await fetch('movies.xml'); // return back "promise"
    const rexml = await response.text();
    const xml = await(new window.DOMParser()).parseFromString(rexml,"text/xml");
    console.log(xml);  //Show document in console.

    $.ajax({  //ajax call
        type: "GET",
        url: "movies.xml",
        dataType: "xml",
        success: function(data) {
            // Create table
           $("table").append('<tr><td>Title</td><td>Genre</td><td>Director</td><td>Cast</td><td>Short Description</td><td>IMDB</td></tr>');
           $(data).find('movie').each(function(){
            var genre = [];
            var cast = [];
            $(this).find("genre").each(function() {
            genre.push($(this).text());
             });
            $(this).find("cast").find("person").each(function() {
            cast.push($(this).attr("name"));
            });
            $("table").append(    //Arrange table content
              "<tr>" + "<td>" + $(this).find("title").text() +
              "</td>" +"<td>" + genre.join(", ") +"</td>" + 
              "<td>" + $(this).find("director").text() + 
              "</td>" + "<td>" + cast.join(", ") + 
              "</td>" + "<td>" + $(this).find("imdb-info").find("synopsis").text() +
              "</td>" + "<td>" + $(this).find("imdb-info").find("score").text() +
              "</td>" + "</tr>"
              );
            });
          },
          error: function() { alert("Error!");  }
        });
   

}
