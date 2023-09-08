import React, { useState, useEffect } from "react";
import PocketBase from "pocketbase";

// const REACT_APP_POCKETBASE_IP = process.env.REACT_APP_POCKETBASE_IP 
// const REACT_APP_POCKETBASE_PORT = process.env.REACT_APP_POCKETBASE_PORT

const Home = () => {
  const [searchInput, setSearchInput] = useState("");
  const [searchResults, setSearchResults] = useState([]);
  const [error, setError] = useState("");
  const [filteredResults, setFilteredResults] = useState([]);
  const [collectionId, setCollectionId] = useState("s1ve699cq867gpe");
  const [REACT_APP_POCKETBASE_IP, setpb_ip] = useState('172.17.0.1');
  const [REACT_APP_POCKETBASE_PORT, setpb_port] = useState('8092');

  useEffect(() => {
    fetchData();
  }, [searchInput]);

  const fetchData = async (searchTerm = "") => {
    try {
      console.log(`http://${REACT_APP_POCKETBASE_IP}:${REACT_APP_POCKETBASE_PORT}`)
      const pb = new PocketBase(`http://${REACT_APP_POCKETBASE_IP}:${REACT_APP_POCKETBASE_PORT}`);
      await pb.admins.authWithPassword(
        "e-mail",
        "password"
      );
      let resultList;

      if (searchTerm) {
        resultList = await pb.collection("Tool").getList(1, 50, {
          filter: `Tool_Name^"${searchTerm}"||Tool_Text^"${searchTerm}"`,
        });
      } else {
        resultList = await pb
          .collection("Tool")
          .getFullList({ expand: "Tool_Name,Tool_Text" });
      }

      const updatedData = Array.isArray(resultList)
        ? resultList.map((item) => ({
            Tool_Id: item.id,
            Tool_Name: item.Tool_Name,
            Tool_Text: item.Tool_Text,
            Tool_URl: item.Tool_URl,
            Tool_Image: item.Tool_Image,
          }))
        : [];
      const errorMsg = resultList.length === 0 ? "No results found." : "";
      setError(errorMsg);
      setSearchResults(updatedData);
      setFilteredResults(updatedData);
      setSearchInput("");
    } catch (error) {
      console.error("Error fetching data:", error);
      setError(error.message || "Error fetching data. Please try again later.");
      setSearchResults([]);
      setFilteredResults([]);
    }
  };

  const handleFilter = (filterTerm) => {
    if (filterTerm === "") {
      setFilteredResults(searchResults);
    } else {
      const filtered = searchResults.filter((item) =>
        item.Tool_Name.toLowerCase().startsWith(filterTerm.toLowerCase())
      );
      setFilteredResults(filtered);
    }
  };

  return (
    <div style={{ marginTop: "80px" }}>
      <div
        className="input-group"
        style={{ width: "60%", margin: "auto", textAlign: "center" }}
      >
        <input
          type="text"
          className="form-control"
          id="filterInput"
          placeholder="Filter results..."
          onChange={(e) => handleFilter(e.target.value)}
          style={{ textAlign: "center" }}
        />
      </div>
      <div className="container mt-4">
        <div className="row">
          {filteredResults.length > 0 &&
            filteredResults.map((item, index) => (
              <div className="col-sm-6 my-3" key={index}>
                <div className="card">
                  <div className="row no-gutters">
                    <div className="col-md-3">
                      <div className="d-flex align-items-center justify-content-center h-100">
                        {item.Tool_Image && (
                          <img
                            className="card-img"
                            src={item.Tool_Image}
                            onError={(e) => {
                              e.target.src = `http://${REACT_APP_POCKETBASE_IP}:${REACT_APP_POCKETBASE_PORT}/api/files/${collectionId}/${item.Tool_Id}/${item.Tool_Image}`;
                            }}
                            style={{
                              width: "150px",
                              height: "150px",
                              borderRadius: "15%",
                              padding: "0px 10px",
                            }}
                            alt=""
                          />
                        )}
                      </div>
                    </div>
                    <div className="col-md-9">
                      <div style={{ height: "125px", overflow: "hidden" }}>
                        <div className="card-body">
                          <h5 className="card-title">{item.Tool_Name}</h5>
                          <div
                            className="card-text"
                            style={{ maxHeight: "65px", overflowY: "auto" }}
                          >
                            {item.Tool_Text}
                          </div>
                        </div>
                      </div>
                      <div>
                        <a
                          href={item.Tool_URl}
                          target="_blank"
                          className="btn btn-primary"
                          rel="noopener noreferrer"
                          style={{
                            float: "right",
                            marginBottom: "10px",
                            marginRight: "10px",
                          }}
                        >
                          Go to Ap
                        </a>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default Home;
