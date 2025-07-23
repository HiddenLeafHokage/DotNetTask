import React, { useState } from "react";

interface LoginProps {
  onLogin: (email: string, password: string) => void;
}

const DEMO_EMAIL = "chukwukasolomon28@gmail.com";
const DEMO_PASSWORD = "DotNetTask";

const Login: React.FC<LoginProps> = ({ onLogin }) => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    setTimeout(() => {
      onLogin(email, password);
      setLoading(false);
    }, 1000);
  };

  return (
    <div className="min-h-screen bg-gray-50 flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
      <div className="max-w-md w-full space-y-8">
        <div>
          <div className="mx-auto h-100 w-100  rounded-lg flex items-center justify-center">
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
          <h2 className="mt-6 text-center text-3xl font-extrabold text-gray-900">
            Apple Store
          </h2>
          <p className="mt-2 text-center text-sm text-gray-600">
        Please sign in to your account.
          </p>
        </div>

        <form className="mt-8 space-y-6" onSubmit={handleSubmit}>
          <div className="space-y-4">
            <div>
              <label htmlFor="email" className="sr-only">
                Email address
              </label>
              <input
                id="email"
                name="email"
                type="email"
                autoComplete="email"
                required
                className="input-field"
                placeholder="Email address"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </div>
            <div>
              <label htmlFor="password" className="sr-only">
                Password
              </label>
              <input
                id="password"
                name="password"
                type="password"
                autoComplete="current-password"
                required
                className="input-field"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>
          </div>

          <div>
            <button
              type="submit"
              disabled={loading}
              className="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-gray-800 hover:bg-gray-1000 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-gray-500 disabled:opacity-50 disabled:cursor-not-allowed"
            >
              {loading ? (
                <div className="flex items-center">
                  <div className="animate-spin rounded-full h-4 w-4 border-b-2 border-white mr-2"></div>
                  Signing in...
                </div>
              ) : (
                "Sign in"
              )}
            </button>
          </div>

          <div className="text-center">
            <p className="text-sm text-gray-800">
              Use This  credentials: <br />
              <span className="font-mono text-xs bg-gray-100 px-2 py-1 rounded">
                {DEMO_EMAIL} / {DEMO_PASSWORD}
              </span>
            </p>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Login;
