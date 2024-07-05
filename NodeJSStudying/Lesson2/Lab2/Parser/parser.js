function parseStr(str, unsorted = true) {
  const charCount = {};

  for (let char of str) {
    if (charCount[char]) {
      charCount[char]++;
    } else {
      charCount[char] = 1;
    }
  }

  // console.log("asd", charCount);
  
  return charCount;
  
  // Це був тотальний провал із сортуванням *facepalm* 
  // const newCharCount = {};

  // const sortedKeys = Object.keys(charCount).sort((a, b) => charCount[b] - charCount[a]);
  // console.log(sortedKeys);

  // sortedKeys.forEach(key => {
  //   newCharCount[key] = charCount[key];
  // });

  // return newCharCount;
}

module.exports.parseStr = parseStr;