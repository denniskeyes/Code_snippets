//Truncates a string if it is longer than the given maximum string length. 
//Return the truncated string with a ... ending.

//Note that inserting the three dots to the end will add to the string length.

//If the given maximum string length num is less than or equal to 3, then the addition of the three dots does not add to the string length in determining the truncated string.


function truncateString(str, num) {
  var trunc = '';

  if (num > 3){
    if (str.length > num){
      trunc = str.slice(0,num-3) + '...';
    }
    else{
      trunc = str;
    }
  }
  else{
    trunc = str.slice(0,num) + '...';
  }
  
  console.log(trunc);
  return trunc;
}

truncateString("A-tisket a-tasket A green and yellow basket", 11);
