import { useState, useEffect } from "react";
import PizzaList from "./PizzaList";
import { DropdownButton, Dropdown } from "react-bootstrap";

function PizzeriaDropdown() {
  const [selectedItem, setSelected] = useState(null);

  const [pizzerias, setPizzerias] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("pizzeria");
        const data = await response.json();
        setPizzerias(data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, []);

  const handleSelect = (eventKey, event) => {
    setSelected(eventKey);
  };

  return (
    <DropdownButton title={selectedItem ? selectedItem.value : "Select an item"} onSelect={handleSelect}>
      {pizzerias.map((item, index) => (
        <Dropdown.Item key={index} eventKey={item.key}>
          {item.key}: {item.value}
        </Dropdown.Item>
      ))}
    </DropdownButton>
  );
}

export default PizzeriaDropdown;
