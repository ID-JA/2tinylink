type InputProps = {
  label?: string
  id?: string
  placeholder?: string
  required?: boolean
} & React.InputHTMLAttributes<HTMLInputElement>

function Input({
  label,
  id,
  placeholder,
  required,
  type,
  className,
  ...props
}: InputProps) {
  return (
    <div className={className}>
      {label && (
        <label
          htmlFor={id}
          className="block mb-2 text-sm font-medium text-gray-600"
        >
          {label}
        </label>
      )}
      <input
        type={type}
        id={id}
        className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
        placeholder="John"
        {...props}
      />
    </div>
  )
}

export default Input
