//OPTION 1: COMPARE FRONT TO BACK
function palindrome(str) {
  
  var newstring1 = str.replace(/ /g,''); //remove spaces
  var newstring2 = newstring1.replace(/[-!$%^&*()_+|~=`{}\[\]:";'<>?,.\/]/g,'').toLowerCase();  //remove punctuation and convert to lowercase
  var strlen = newstring2.length;
  var strarray = newstring2.split('');
  
  for (var i = 0; i < strlen/2; i++){
     if (strarray[i] !== strarray[strlen-1-i]){
       return false;
     }
   }

  return true;
}





//OPTION 2: CONVERT TO ARRAY, REVERSE, CONVERT BACK TO STRING, AND COMPARE TO ORIGINAL
function palindrome(str) {
  return str.replace(/[\W_]/g, '').toLowerCase() ===
         str.replace(/[\W_]/g, '').toLowerCase().split('').reverse().join('');
}
