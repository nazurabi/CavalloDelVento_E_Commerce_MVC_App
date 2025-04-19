### CavalloDelVento_E_Commerce_MVC_App

This project consists of two integrated applications developed for managing and selling **bicycle spare parts**:

1. **Desktop Application for Main Dealer (Factory)**
2. **E-Commerce Website for Sub-Dealers**

The system is designed to streamline inventory and product distribution between the main dealer and sub-dealers, allowing sub-dealers to sell products to end customers via a web-based e-commerce platform.

---
## 🧩 Project Components

### 1. Main Dealer Desktop Application

- **Purpose**: Allows the main dealer (factory) to manage product inventory and distribute products to sub-dealers.
- **Technology**: Developed with Visual Studio (Windows Forms)
- **Key Features**:
  - Add / Update / Delete products
  - Manage stock entries and exits
  - Send products to registered sub-dealers
  - Export product data to sub-dealers via XML
  - Member types with discount rates:
    - 🥇 Gold: 10% discount  
    - 🥈 Silver: 5% discount  
    - 🥉 Bronze: 2% discount

### 2. Sub-Dealer E-Commerce Website

- **Purpose**: Allows sub-dealers to sell products received from the main dealer to end customers through their own e-commerce portal.
- **Technology**: MVC-based Web Application (e.g., ASP.NET MVC)
- **Key Features**:
  - Product listing and search functionality
  - Product details and category filtering
  - Add to cart and place orders
  - User registration and login system
  - Discount system based on membership type
  - Manual product addition (optional for sub-dealers)
  - Manage stock quantity

---
## ⚙️ Installation & Setup

### Desktop Application

1. Open the project in Visual Studio
2. Restore required NuGet packages
3. Configure the database connection and migrations
4. Build and run the application

---
## 🔗 System Architecture
[Desktop App: Main Dealer] <---> [Database / XML Sync] <---> [Web App: Sub-Dealers]
           |                                                          |
Product Entry & Export                                       Product Display & Sales

---
📬 Contact
For questions or support, feel free to reach out at: nasuhberber@gmail.com

📄 License
This project is licensed under the MIT License.

