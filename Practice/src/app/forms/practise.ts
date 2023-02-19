let token: string ;
token="token"

let x=10;
let y=9;
let z:number;
z=x+y;

let name1="vinodh";
 let sentence=`he is a good guy ${name1}`;
let n:undefined=undefined;  
let list1:number[]= [1,3,6];

let list2:Array<number>=[1,2,3];
let list3:Array<any>=[1,"lpook"];


let list4:[string,number,number]=["pol",1,3];

enum colour{
    "red"=1,"blue","green",
}
console.log(colour.red);

let list5:string="pskks"


let l=list5.toUpperCase();
console.log(l);

let union:string|number|boolean;

union="ldlldp";

function add(x :number,y:number) {
    return x+y;
    
     
}
 
interface add1{
    x:number;
y:number;
z:number;
}

function Add(pop:add1)
{
    return pop.x+pop.y+pop.z;

}

console.log(Add({x:1,y:2,z:3}));


   








    