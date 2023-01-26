window.onload = function(){

  //there will be one span element for each input field
  // when the page is loaded, we create them and append them to corresponding input elements 
	// they are initially empty and hidden

  //Create span element using create element or DOM insert.
	var email = document.getElementById("email");
  var pwd = document.getElementById("pwd");
  var confirm = document.getElementById("confirm");

  var emailSpan = document.createElement("span");
  var pwdSpan = document.createElement("span");
  var confirmSpan = document.createElement("span");

	emailSpan.style.display = "none"; //Hide the span element
  pwdSpan.style.display = "none";
  confirmSpan.style.display = "none";

  email.parentNode.appendChild(emailSpan);
  pwd.parentNode.appendChild(pwdSpan);
  confirm.parentNode.appendChild(confirmSpan);

  var form = document.getElementById("myForm");

  email.onfocus = function(){
    emailSpan.style.display = "block";
    emailSpan.textContent = "Please enter an email, type as abc@def.xyz"
  }

  email.onblur = function(){
    emailSpan.style.display = "none"; 
    emailSpan.textContent = "";
    email.classList.remove('error'); // HighLight meaning change class to error.
  }

  pwd.onfocus = function(){
    pwdSpan.style.display = "block";
    pwdSpan.textContent = "Please enter the password with at least 6 digits"
  }

  pwd.onblur = function(){
    pwdSpan.style.display = "none"; 
    pwdSpan.textContent = "";
    pwd.classList.remove('error'); 
  }

  confirm.onfocus = function(){
    confirmSpan.style.display = "block";
    pwd.classList.remove('error'); 
  }

  confirm.onblur = function(){
    confirmSpan.style.display = "none"; 
    confirmSpan.textContent = "";
    pwd.classList.remove('error'); 
    confirm.classList.remove('error'); 
  }

  form.onsubmit = function(e){
    e.preventDefault(); // prevent submit
    validate(emailSpan,email,pwdSpan,pwd,confirmSpan,confirm);
  }

  function validate(emailSpan,email,pwdSpan,pwd,confirmSpan,confirm){

    var flag= true;

    const emailRE = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;

        if (!emailRE.test(email.value)) {
            email.classList.add('error');
            emailSpan.textContent = "The email address is not valid, please give another email address.";
            emailSpan.style.display = 'block';
            flag  = false;
            
        }
        if (pwd.value.length < 6) {
            pwd.classList.add('error');
            confirm.classList.add('error');
            pwdSpan.textContent = "Password should be at least 6 digits.";
            pwdSpan.style.display = 'block';
            flag = false;
         
        }
        if (!(confirm.value == pwd.value)) {
            pwd.classList.add('error');
            confirm.classList.add('error');
            confirmSpan.textContent = "The password your enter is not match previous password.";
            confirmSpan.style.display = 'block';
            flag  = false;
        }
        if (flag) {

                email.classList.remove('error');
                pwd.classList.remove('error');
                confirm.classList.remove('error');

                document.getElementById("myForm").submit();
                alert ("Form submit Suceess.");
         }
    return flag;
  }
}

