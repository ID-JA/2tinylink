import Input from '@/components/common/Input'
import Head from 'next/head'

function RegisterPage() {
  return (
    <>
      <Head>
        <title>Sign up</title>
      </Head>
      <div className="flex flex-col items-center justify-center h-screen">
        <a href="#" className="absolute left-5 top-5 flex items-center">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="20"
            height="20"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2"
            stroke-linecap="round"
            stroke-linejoin="round"
          >
            <polyline points="15 18 9 12 15 6"></polyline>
          </svg>
          <span>
            To <span className="text-primary-500 font-bold">Home Page</span>
          </span>
        </a>
        <h1 className="text-xl font-semibold text-gray-700 mb-6 text-center">
          Sign up to
          <span className="text-blue-600 font-bold"> 2tinylink</span>
        </h1>
        <div className="w-full max-w-md p-6 border shadow-sm rounded-md py-8 ">
          <form className="px-4">
            <div className="flex gap-4 mb-6">
              <Input label="First Name" />
              <Input label="Last Name" />
            </div>
            <Input label="Email" type="email" className="mb-6" />
            <Input label="Password" type="password" className="mb-6" />
            <div className="flex">
              <button
                type="button"
                className="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 active:scale-95 w-full"
              >
                Create Account
              </button>
            </div>
            <p className="text-gray-500 text-sm mt-5 leading-6">
              By signing up, you agree to our{' '}
              <a href="#" className="underline">
                Terms of Service
              </a>{' '}
              and{' '}
              <a href="#" className="underline">
                Privacy Policy
              </a>
            </p>
          </form>
        </div>
      </div>
    </>
  )
}

export default RegisterPage
