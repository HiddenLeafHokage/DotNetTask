import React, { useState, useEffect } from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link,
  useLocation,
  Navigate,
} from "react-router-dom";
import ProductCard from "./components/ProductCard";
import Cart from "./components/Cart";
import Login from "./components/Login";
import { productApi, cartApi } from "./services/api";
import type { CartItem, Product } from "./types";
import {
  FaBagShopping,
  FaBoxesStacked,
  FaArrowRightFromBracket,
} from "react-icons/fa6";

const Navigation: React.FC<{ cartItemCount: number; onLogout: () => void }> = ({
  cartItemCount,
  onLogout,
}) => {
  const location = useLocation();

  return (
    <nav className="bg-white shadow-lg border-b border-gray-100 sticky top-0 z-50">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between items-center h-16">
          <Link to="/" className="flex items-center space-x-2">
           <div className="w-8 h-8  flex items-center justify-center">
  
  <svg
  xmlns="http://www.w3.org/2000/svg"
  className="w-8 h-8 text-black"
  viewBox="0 0 225 225"
  fill="currentColor"
>
  {/* Top leaf */}
  <path d="m108,35
    c5.587379,-6.7633 9.348007,-16.178439 8.322067,-25.546439
    c-8.053787,0.32369 -17.792625,5.36682 -23.569427,12.126399
    c-5.177124,5.985922 -9.711121,15.566772 -8.48777,24.749359
    c8.976891,0.69453 18.147476,-4.561718 23.73513,-11.329308"
  />

  {/* Apple left half */}
  <path d="M88,162.415214
    c-12.24469,0 -16.072174,6.151901 -26.213551,6.550446
    c-10.52422,0.398254 -18.538303,-10.539917 -25.26247,-20.251053
    c-13.740021,-19.864456 -24.24024,-56.132286 -10.1411,-80.613663
    c7.004152,-12.157551 19.521101,-19.85622 33.10713,-20.053638
    c10.334515,-0.197132 20.089069,6.952717 26.406689,6.952717"
  />

  {/* Apple right half */}
  <path d="M85,55
    c6.313614,0 18.167473,-8.59832 30.628998,-7.335548
    c5.21682,0.217129 19.860519,2.1073 29.263641,15.871029
    c-0.75766,0.469692 -17.472931,10.200527 -17.291229,30.443592
    c0.224838,24.213104 21.241287,32.270615 21.474121,32.373459
    c-0.177704,0.56826 -3.358078,11.482742 -11.072464,22.756622
    c-6.668747,9.746841 -13.590027,19.457977 -24.493088,19.659103
    c-10.713348,0.197403 -14.158287,-6.353043 -26.406677,-6.353043"
  />
</svg>

  
</div>

            <span className="text-xl font-bold text-gray-900">Apple Store</span>
          </Link>

          <div className="flex items-center space-x-8">
            <Link
              to="/"
              className={`text-sm font-medium transition-colors ${
                location.pathname === "/"
                  ? "text-gray-900"
                  : "text-gray-500 hover:text-gray-900"
              }`}
            >
              <FaBoxesStacked className="w-6 h-6" />
            </Link>
            <Link
              to="/cart"
              className="relative text-sm font-medium text-gray-500 hover:text-gray-900 transition-colors"
            >
              <FaBagShopping className="w-6 h-6" />
              {cartItemCount > 0 && (
                <span className="absolute -top-2 -right-2 bg-gray-900 text-white text-xs rounded-full h-5 w-5 flex items-center justify-center">
                  {cartItemCount}
                </span>
              )}
            </Link>
            <button
              onClick={onLogout}
              className="text-sm font-medium text-gray-500 hover:text-gray-900 transition-colors flex items-center gap-1"
            >
              <FaArrowRightFromBracket className="w-6 h-6" />
            </button>
          </div>
        </div>
      </div>
    </nav>
  );
};

const ProductsPage: React.FC<{ onAddToCart: (productId: number) => void }> = ({
  onAddToCart,
}) => {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const data = await productApi.getAll();
        setProducts(data);
      } catch (err) {
        setError("Failed to load products. Please try again later.");
      } finally {
        setLoading(false);
      }
    };

    fetchProducts();
  }, []);

  if (loading) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <div className="text-center">
          <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-gray-600 mx-auto"></div>
          <p className="mt-4 text-gray-600">Loading products...</p>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <div className="text-center">
          <div className="w-16 h-16 bg-gray-100 rounded-full flex items-center justify-center mx-auto mb-4">
            <svg
              className="w-8 h-8 text-gray-600"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth={2}
                d="M12 8v4m0 4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
              />
            </svg>
          </div>
          <p className="text-gray-600">{error}</p>
        </div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gray-50">
      <div className="bg-gradient-to-r from-gray-600 to-gray-200 text-white">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-16">
          <div className="text-center">
            <h1 className="text-4xl text-gray-900 font-bold mb-4">Welcome to Apple Store</h1>
            <p className="text-xl text-gray-900 max-w-2xl mx-auto">
              Discover the latest in technology with our premium selection of
              gadgets and electronics.
            </p>
          </div>
        </div>
      </div>

      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6">
          {products.map((product) => (
            <ProductCard
              key={product.id}
              product={product}
              onAddToCart={onAddToCart}
            />
          ))}
        </div>
      </div>
    </div>
  );
};

const CartPage: React.FC<{
  cartItems: CartItem[];
  onUpdateQuantity: (cartItemId: number, quantity: number) => void;
  onRemoveItem: (cartItemId: number) => void;
}> = ({ cartItems, onUpdateQuantity, onRemoveItem }) => {
  return (
    <div className="min-h-screen bg-gray-50 py-8">
      <Cart
        cartItems={cartItems}
        onUpdateQuantity={onUpdateQuantity}
        onRemoveItem={onRemoveItem}
      />
    </div>
  );
};

const App: React.FC = () => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [cartItems, setCartItems] = useState<CartItem[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const token = localStorage.getItem("authToken");
    if (token) {
      setIsAuthenticated(true);
    }
    setLoading(false);
  }, []);

  useEffect(() => {
    if (isAuthenticated) {
      const loadCart = async () => {
        try {
          const items = await cartApi.getCart();
          setCartItems(items);
        } catch (err) {
          console.error("Failed to load cart:", err);
        }
      };
      loadCart();
    }
  }, [isAuthenticated]);

  const handleLogin = (email: string, password: string) => {
    if (email === "chukwukasolomon28@gmail.com" && password === "DotNetTask") {
      localStorage.setItem("authToken", "demo-token");
      setIsAuthenticated(true);
    } else {
      alert("Invalid credentials. Use: chukwukasolomon28@gmail.com / DotNetTask");
    }
  };

  const handleLogout = () => {
    localStorage.removeItem("authToken");
    setIsAuthenticated(false);
    setCartItems([]);
  };

  const handleAddToCart = async (productId: number) => {
    try {
      await cartApi.addToCart(productId, 1);

      const items = await cartApi.getCart();
      setCartItems(items);
    } catch (err) {
      console.error("Failed to add to cart:", err);
    }
  };

  const handleUpdateQuantity = async (cartItemId: number, quantity: number) => {
    try {
      if (quantity === 0) {
        await cartApi.removeFromCart(cartItemId);
      } else {
        await cartApi.updateCart(cartItemId, quantity);
      }

      const items = await cartApi.getCart();
      setCartItems(items);
    } catch (err) {
      console.error("Failed to update cart:", err);
    }
  };

  const handleRemoveItem = async (cartItemId: number) => {
    try {
      await cartApi.removeFromCart(cartItemId);

      const items = await cartApi.getCart();
      setCartItems(items);
    } catch (err) {
      console.error("Failed to remove item:", err);
    }
  };

  if (loading) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <div className="text-center">
          <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-red-600 mx-auto"></div>
          <p className="mt-4 text-gray-600">Loading...</p>
        </div>
      </div>
    );
  }

  return (
    <Router>
      <div className="App">
        {isAuthenticated ? (
          <>
            <Navigation
              cartItemCount={cartItems.length}
              onLogout={handleLogout}
            />
            <Routes>
              <Route
                path="/"
                element={<ProductsPage onAddToCart={handleAddToCart} />}
              />
              <Route
                path="/cart"
                element={
                  <CartPage
                    cartItems={cartItems}
                    onUpdateQuantity={handleUpdateQuantity}
                    onRemoveItem={handleRemoveItem}
                  />
                }
              />
              <Route path="*" element={<Navigate to="/" replace />} />
            </Routes>
          </>
        ) : (
          <Routes>
            <Route path="/login" element={<Login onLogin={handleLogin} />} />
            <Route path="*" element={<Navigate to="/login" replace />} />
          </Routes>
        )}
      </div>
    </Router>
  );
};

export default App;
