// import { useState, useEffect } from "react";

// function PizzaList(location) {
  
// const [menu, setMenu] = useState([]);

//   useEffect(() => {
//     const fetchData = async () => {
//       try {
//         const response = await fetch('pizzeria/getmenu/'+ location);
//         const data = await response.json();
//         setMenu(data);
//       } catch (error) {
//         console.error("Error fetching data:", error);
//       }
//     };

//     fetchData();
//   }, []);
//   return <ul className="list-group">
//   {menu.map((item, index) => (
//     <li
//       className="list-group-item"
      
//       key={item}
//     >
//       {item}
//     </li>
//   ))}
// </ul>;
// }

// export default PizzaList;
