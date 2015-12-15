import moment from "moment";
 
export default element => {
 
    let pleasantry = "Hello!";
    let timeLeft = moment().startOf("hour").fromNow();
 
    element.innerText = `${pleasantry} The hour started ${timeLeft}`;
};
