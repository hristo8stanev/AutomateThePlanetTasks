let x = -20;
let y = -20;
let z = 2;

if (x > 0 && y > 0 && z > 0) {
    console.log("The sign is +");
} else if (x < 0 && y < 0 && z < 0) {
  console.log("The sign is +");
} else if ((x < 0 && y > 0 && z < 0) || (x > 0 && y < 0 && z < 0) || (x < 0 && y < 0 && z > 0)) {
  console.log("The sign is +");
} else {
  console.log("The sign is -");
}