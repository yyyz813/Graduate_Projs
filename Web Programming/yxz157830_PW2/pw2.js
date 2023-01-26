// Listener for enter key
var input = document.getElementById("userInput");
input.addEventListener("keyup", function(event) {
  if (event.key === 'Enter') {
   event.preventDefault();
   document.getElementById("btn").click();
  }
});

// Add Item
function buttonAdd(){
    var text = document.getElementById("userInput").value;
    const userInput = document.createTextNode(text);
    const li = document.createElement("li");
    li.appendChild(userInput);
    const input = document.getElementById("list");
    input.appendChild(li);
}

// Strike through, Delegation to avoid select all
function strike(){

    const parent = document.querySelector("#Adding");  // Set parent
	parent.addEventListener("click", function (e) {
	// e.target is the object that generated the event. 
	// to verify that e.target exists and that it is one of the
	// <img> elements. Note: NodeName always returns 	//upper case
	if (e.target && e.target.nodeName == "LI") {
            e.target.classList.toggle("lineThrough");
	    }
    });
}

// Delete element from last to least.
function buttonDelete(){
    var list = document.getElementById("list");
    list.removeChild(list.lastChild);
}

