var token;
token = "token";
var x = 10;
var y = 9;
var z;
z = x + y;
var name1 = "vinodh";
var sentence = "he is a good guy ".concat(name1);
var n = undefined;
var list1 = [1, 3, 6];
var list2 = [1, 2, 3];
var list3 = [1, "lpook"];
var list4 = ["pol", 1, 3];
var colour;
(function (colour) {
    colour[colour["red"] = 1] = "red";
    colour[colour["blue"] = 2] = "blue";
    colour[colour["green"] = 3] = "green";
})(colour || (colour = {}));
console.log(colour.red);
var list5 = "pskks";
var l = list5.toUpperCase();
console.log(l);
var union;
union = "ldlldp";
function add(x, y) {
    return x + y;
}
function Add(pop) {
    return pop.x + pop.y + pop.z;
}
console.log(Add({ x: 1, y: 2, z: 3 }));
